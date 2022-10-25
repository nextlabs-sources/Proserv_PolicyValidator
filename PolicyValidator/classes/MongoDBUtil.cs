using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Linq;
using System.Runtime.Serialization;
using System.Windows.Forms;
using log4net;
using PolicyValidator.Properties;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Text;
using System.Threading.Tasks;



namespace PolicyValidator
{

    static class MongoDBUtil
    {

        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private static IMongoClient _client;
        private static IMongoDatabase _database;


        public static string GetBaseDirectory()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Settings.Default.RootDir);
        }

        public static Boolean testDatabaseConnection(string user, string password, string host, string port, string database)
        {
            Log.Info("Test Database client started");

            try
            {
                StringBuilder connectionString = new StringBuilder();
                connectionString.Append("mongodb://");
                connectionString.Append(user + ":");
                connectionString.Append(password + "@");
                connectionString.Append(host + ":");
                connectionString.Append(port + "/");
                connectionString.Append(database);
                _client = new MongoClient(connectionString.ToString());
                _database = _client.GetDatabase(Settings.Default.Database_Name);
                Log.Info(_database.ListCollectionsAsync().Result.ToString());
            }
            catch (Exception ex)
            {
                Log.Error("An error occurred while connecting to the database. ", ex);
                return false;
            }
            Log.Info("Test Database client finished");
            return true;
        }


        public static Boolean getDatabaseClient()
        {
            Log.Info("Initialize Database client started");

            try
            {
                StringBuilder connectionString = new StringBuilder();
                connectionString.Append("mongodb://");
                connectionString.Append(Settings.Default.Database_User + ":");
                connectionString.Append(Settings.Default.Database_Password + "@");
                connectionString.Append(Settings.Default.Database_Host + ":");
                connectionString.Append(Settings.Default.Database_Port + "/");
                connectionString.Append(Settings.Default.Database_Name);
                _client = new MongoClient(connectionString.ToString());
                _database = _client.GetDatabase(Settings.Default.Database_Name);
                Log.Info(_database.ListCollectionsAsync().Result.ToString());
            }
            catch (Exception ex)
            {
                Log.Error("An error occurred while connecting to the database. ", ex);
                return false;
            }
            Log.Info("Initialize Database client finished");
            return true;
        }


        async public static Task<Boolean> CreateNewTestCase(TestCase tc)
        {
            Log.Info("CreateNewTestCase() started");
            Boolean result = true;
            try
            {

                List<BsonDocument> bsonRecipients = new List<BsonDocument>();
                foreach (Subject recipient in tc.Recipients)
                {
                    bsonRecipients.Add(new BsonDocument {
                        {"user_name", recipient.Username},
                        {"windows_sid", recipient.WindowsSid},
                        {"application_name", recipient.ApplicationName},
                        {"ip_address", recipient.IpAddress},
                        {"subject_dynamic_attributes", new BsonArray(recipient.SubjectDynamicAttributes)}
                    });
                }

                var testCaseDocument = new BsonDocument {
                    {"name", tc.Name},
                    {"test_set", tc.TestSet},
                    {"policy_type", tc.PolicyType},
                    {"target_system", tc.TargetSystem},
                    {"expected_result", tc.ExpectedResult},
                    {"subject", new BsonDocument {
                                {"user_name", tc.Subject.Username},
                                {"windows_sid", tc.Subject.WindowsSid},
                                {"application_name", tc.Subject.ApplicationName},
                                {"ip_address", tc.Subject.IpAddress},
                                {"subject_dynamic_attributes", new BsonArray(tc.Subject.SubjectDynamicAttributes)}
                            }
                        },
                    {"action", tc.Action},
                    {"recipients", new BsonArray(bsonRecipients)},
                    {"from_resource", new BsonDocument{
                                {"resource_name", tc.FromResource.ResourceName},
                                {"resource_dynamic_attributes", new BsonArray(tc.FromResource.ResourceDynamicAttributes)}
                            }
                        },
                    {"to_resource", new BsonDocument{
                                {"resource_name", tc.ToResource.ResourceName},
                                {"resource_dynamic_attributes", new BsonArray(tc.ToResource.ResourceDynamicAttributes)}
                            }      
                        },
                    {"email_subject", tc.EmailSubject},
                    {"email_body", tc.EmailBody}
                };

                var collection = _database.GetCollection<BsonDocument>("test_cases");
                await collection.InsertOneAsync(testCaseDocument).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Log.Error("An error occurred while creating new test case in the database. ", ex);
                result = false;
            }

            Log.Info("CreateNewTestCase() finished");

            return result;
        }


        async public static Task<Boolean> CreateNewTestCases(List<TestCase> testCases)
        {
            Log.Info("CreateNewTestCases() started");
            Boolean result = true;
            try
            {
                List<BsonDocument> testCaseDocuments = new List<BsonDocument>();
                List<BsonDocument> bsonRecipients = new List<BsonDocument>();
                foreach (TestCase tc in testCases)
                {
                    bsonRecipients.Clear();
                    foreach (Subject recipient in tc.Recipients)
                    {
                        bsonRecipients.Add(new BsonDocument {
                        {"user_name", recipient.Username},
                        {"windows_sid", recipient.WindowsSid},
                        {"application_name", recipient.ApplicationName},
                        {"ip_address", recipient.IpAddress},
                        {"subject_dynamic_attributes", new BsonArray(recipient.SubjectDynamicAttributes)}
                    });
                    }

                    var testCaseDocument = new BsonDocument {
                    {"name", tc.Name},
                    {"test_set", tc.TestSet},
                    {"policy_type", tc.PolicyType},
                    {"target_system", tc.TargetSystem},
                    {"expected_result", tc.ExpectedResult},
                    {"subject", new BsonDocument {
                                {"user_name", tc.Subject.Username},
                                {"windows_sid", tc.Subject.WindowsSid},
                                {"application_name", tc.Subject.ApplicationName},
                                {"ip_address", tc.Subject.IpAddress},
                                {"subject_dynamic_attributes", new BsonArray(tc.Subject.SubjectDynamicAttributes)}
                            }
                        },
                    {"action", tc.Action},
                    {"recipients", new BsonArray(bsonRecipients)},
                    {"from_resource", new BsonDocument{
                                {"resource_name", tc.FromResource.ResourceName},
                                {"resource_dynamic_attributes", new BsonArray(tc.FromResource.ResourceDynamicAttributes)}
                            }
                        },
                    {"to_resource", new BsonDocument{
                                {"resource_name", tc.ToResource.ResourceName},
                                {"resource_dynamic_attributes", new BsonArray(tc.ToResource.ResourceDynamicAttributes)}
                            }      
                        },
                    {"email_subject", tc.EmailSubject},
                    {"email_body", tc.EmailBody}
                };
                    testCaseDocuments.Add(testCaseDocument);
                }

                var collection = _database.GetCollection<BsonDocument>("test_cases");
                await collection.InsertManyAsync(testCaseDocuments).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Log.Error("An error occurred while creating new test cases in the database. ", ex);
                result = false;
            }

            Log.Info("CreateNewTestCases() finished");

            return result;
        }


        async public static Task<Boolean> CheckTestCaseExistence(string testCaseName, string testSetName)
        {
            Log.Info("CheckTestCaseExistence() started");
            Boolean exist = true;
            try
            {
                var collection = _database.GetCollection<BsonDocument>("test_cases");
                var builder = Builders<BsonDocument>.Filter;
                var filter = builder.Eq("name", testCaseName) & builder.Eq("test_set", testSetName);
                var result = await collection.Find(filter).ToListAsync().ConfigureAwait(false);

                if (result.Count == 0)
                {
                    exist = false;
                }
            }
            catch (Exception ex)
            {
                Log.Error("An error occurred while checking test case existence in the database. ", ex);
                throw new Exception("Failed to check for test case existence");
            }

            Log.Info("CheckTestCaseExistence() finished");

            return exist;
        }

        async public static Task<TestCase> GetTestCase(string testCaseName, string testSetName)
        {
            Log.Info("GetTestCase() started");
            TestCase testCase = null;
            try
            {
                var collection = _database.GetCollection<BsonDocument>("test_cases");
                var builder = Builders<BsonDocument>.Filter;
                var filter = builder.Eq("name", testCaseName) & builder.Eq("test_set", testSetName);
                var result = await collection.Find(filter).ToListAsync().ConfigureAwait(false);

                if (result.Count == 0)
                {
                    throw new Exception("Cannot find test case");
                }

                if (result.Count > 1)
                {
                    throw new Exception("More than one test case found");
                }

                List<BsonDocument> testCasesDocument = result.ToList<BsonDocument>();
                BsonDocument document = testCasesDocument.ElementAt(0);

                TargetSystem targetSystem = (TargetSystem)document.GetValue("target_system").AsInt32;
                Decision expectedResult = (Decision)document.GetValue("expected_result").AsInt32;
                PolicyType policyType = (PolicyType)document.GetValue("policy_type").AsInt32;
                string action = document.GetValue("action").AsString;

                //get subject
                BsonDocument bsonSubject = document.GetValue("subject").AsBsonDocument;

                List<string> subjectDynamicAttributes = new List<string>();
                BsonArray bsonSubjectAttributes = bsonSubject.GetValue("subject_dynamic_attributes").AsBsonArray;
                foreach (BsonValue value in bsonSubjectAttributes.Values)
                {
                    subjectDynamicAttributes.Add(value.AsString);
                }

                Subject subject = new Subject(bsonSubject.GetValue("user_name").AsString, bsonSubject.GetValue("windows_sid").AsString,
                    bsonSubject.GetValue("application_name").AsString, bsonSubject.GetValue("ip_address").AsString, subjectDynamicAttributes);

                //get from resource
                BsonDocument bsonFromResource = document.GetValue("from_resource").AsBsonDocument;

                List<string> fromResourceDynamicAttributes = new List<string>();
                BsonArray bsonFromResourceAttributes = bsonFromResource.GetValue("resource_dynamic_attributes").AsBsonArray;
                foreach (BsonValue value in bsonFromResourceAttributes.Values)
                {
                    fromResourceDynamicAttributes.Add(value.AsString);
                }

                Resource fromResource = new Resource(bsonFromResource.GetValue("resource_name").AsString, fromResourceDynamicAttributes);

                //get to resource
                BsonDocument bsonToResource = document.GetValue("to_resource").AsBsonDocument;

                List<string> toResourceDynamicAttributes = new List<string>();
                BsonArray bsonToResourceAttributes = bsonFromResource.GetValue("resource_dynamic_attributes").AsBsonArray;
                foreach (BsonValue value in bsonToResourceAttributes.Values)
                {
                    toResourceDynamicAttributes.Add(value.AsString);
                }

                Resource toResource = new Resource(bsonToResource.GetValue("resource_name").AsString, toResourceDynamicAttributes);

                //get recipients
                List<Subject> recipients = new List<Subject>();
                BsonArray bsonRecipients = document.GetValue("recipients").AsBsonArray;
                List<string> recipientAttributes = new List<string>();
                foreach (BsonValue value in bsonRecipients)
                {
                    BsonDocument bsonRecipient = value.AsBsonDocument;
                    recipientAttributes.Clear();
                    BsonArray bsonRepAttributes = bsonRecipient.GetValue("subject_dynamic_attributes").AsBsonArray;
                    foreach (BsonValue attr in bsonRepAttributes.Values)
                    {
                        recipientAttributes.Add(value.AsString);
                    }
                    
                    recipients.Add(new Subject(bsonRecipient.GetValue("user_name").AsString, bsonRecipient.GetValue("windows_sid").AsString,
                    bsonRecipient.GetValue("application_name").AsString, bsonRecipient.GetValue("ip_address").AsString, recipientAttributes));
                }

                //get email values
                string emailSubject = document.GetValue("email_subject").AsString;
                string emailBody = document.GetValue("email_body").AsString;


                testCase = new TestCase(testCaseName, testSetName, targetSystem, expectedResult, policyType, subject,
                    action, fromResource, toResource, recipients, emailSubject, emailBody);
            }
            catch (Exception ex)
            {
                Log.Error("An error occurred while getting test case in the database. ", ex);
                throw new Exception("Failed to get test case");
            }

            Log.Info("GetTestCase() finished");

            return testCase;
        }


        async public static Task<Boolean> UpdateTestCase(TestCase tc, String oldName)
        {
            Log.Info("UpdateTestCase() started");
            Boolean result = true;

            try
            {
                List<BsonDocument> bsonRecipients = new List<BsonDocument>();
                foreach (Subject recipient in tc.Recipients)
                {
                    bsonRecipients.Add(new BsonDocument {
                        {"user_name", recipient.Username},
                        {"windows_sid", recipient.WindowsSid},
                        {"application_name", recipient.ApplicationName},
                        {"ip_address", recipient.IpAddress},
                        {"subject_dynamic_attributes", new BsonArray(recipient.SubjectDynamicAttributes)}
                    });
                }

                var testCaseDocument = new BsonDocument {
                    {"name", tc.Name},
                    {"test_set", tc.TestSet},
                    {"policy_type", tc.PolicyType},
                    {"target_system", tc.TargetSystem},
                    {"expected_result", tc.ExpectedResult},
                    {"subject", new BsonDocument {
                                {"user_name", tc.Subject.Username},
                                {"windows_sid", tc.Subject.WindowsSid},
                                {"application_name", tc.Subject.ApplicationName},
                                {"ip_address", tc.Subject.IpAddress},
                                {"subject_dynamic_attributes", new BsonArray(tc.Subject.SubjectDynamicAttributes)}
                            }
                        },
                    {"action", tc.Action},
                    {"recipients", new BsonArray(bsonRecipients)},
                    {"from_resource", new BsonDocument{
                                {"resource_name", tc.FromResource.ResourceName},
                                {"resource_dynamic_attributes", new BsonArray(tc.FromResource.ResourceDynamicAttributes)}
                            }
                        },
                    {"to_resource", new BsonDocument{
                                {"resource_name", tc.ToResource.ResourceName},
                                {"resource_dynamic_attributes", new BsonArray(tc.ToResource.ResourceDynamicAttributes)}
                            }      
                        },
                    {"email_subject", tc.EmailSubject},
                    {"email_body", tc.EmailBody}
                };

                var collection = _database.GetCollection<BsonDocument>("test_cases");
                var builder = Builders<BsonDocument>.Filter;
                var filter = builder.Eq("name", oldName) & builder.Eq("test_set", tc.TestSet);
                await collection.ReplaceOneAsync(filter, testCaseDocument).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Log.Error("An error occurred while updating test case in the database. ", ex);
                result = false;
            }

            Log.Info("UpdateTestCase() finished");
            return result;
        }


        async public static Task<Boolean> BulkUpdateTestCasesOfTestSet(string testSet, string key, string updatedValue)
        {
            Log.Info("BulkUpdateTestCasesOfTestSet() started");
            Boolean result = true;

            try
            {
                var collectionCase = _database.GetCollection<BsonDocument>("test_cases");
                var builderCase = Builders<BsonDocument>.Filter;
                var filterCase = builderCase.Eq("test_set", testSet);
                var update = Builders<BsonDocument>.Update.Set(key, updatedValue);
                await collectionCase.UpdateManyAsync(filterCase, update).ConfigureAwait(false);

            }
            catch (Exception ex)
            {
                Log.Error("An error occurred while bulk updating test cases in the database. ", ex);
                result = false;
            }

            Log.Info("BulkUpdateTestCasesOfTestSet() finished");
            return result;
        }


        async public static Task<Boolean> DeleteTestCase(String testCase, String testSet)
        {
            Log.Info("DeleteTestCase() started");
            Boolean result = true;
            try
            {
                var collection = _database.GetCollection<BsonDocument>("test_cases");
                var builder = Builders<BsonDocument>.Filter;
                var filter = builder.Eq("name", testCase) & builder.Eq("test_set", testSet);
                await collection.DeleteManyAsync(filter).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Log.Error("An error occurred while deleting test case in the database. ", ex);
                result = false;
            }

            Log.Info("DeleteTestCase() finished");
            return result;
        }


        async public static Task<Boolean> CreateNewTestSet(string name)
        {
            Log.Info("CreateNewTestSet() started");
            Boolean result = true;
            try
            {
                var testSetDocument = new BsonDocument {
                    {"name", name}
                };

                var collection = _database.GetCollection<BsonDocument>("test_set");
                await collection.InsertOneAsync(testSetDocument).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Log.Error("An error occurred while creating new test set in the database. ", ex);
                result = false;
            }

            Log.Info("CreateNewTestSet() finished");

            return result;
        }

        async public static Task<Boolean> UpdateTestSet(string newName, string oldName)
        {
            Log.Info("UpdateTestSet() started");
            Boolean result = true;

            try
            {
                var testSetDocument = new BsonDocument {
                    {"name", newName},
                };

                var collectionSet = _database.GetCollection<BsonDocument>("test_set");
                var builderSet = Builders<BsonDocument>.Filter;
                var filterSet = builderSet.Eq("name", oldName);
                await collectionSet.ReplaceOneAsync(filterSet, testSetDocument).ConfigureAwait(false);

                var collectionCase = _database.GetCollection<BsonDocument>("test_cases");
                var builderCase = Builders<BsonDocument>.Filter;
                var filterCase = builderCase.Eq("test_set", oldName);
                var update = Builders<BsonDocument>.Update.Set("test_set", newName);
                await collectionCase.UpdateManyAsync(filterCase, update).ConfigureAwait(false);

            }
            catch (Exception ex)
            {
                Log.Error("An error occurred while updating test set in the database. ", ex);
                result = false;
            }

            Log.Info("UpdateTestSet() finished");
            return result;
        }


        async public static Task<Boolean> CheckTestSetExistence(string name)
        {
            Log.Info("CheckTestSetExistence() started");
            Boolean exist = true;
            try
            {
                var collection = _database.GetCollection<BsonDocument>("test_set");
                var filter = Builders<BsonDocument>.Filter.Eq("name", name);
                var result = await collection.Find(filter).ToListAsync().ConfigureAwait(false);

                if (result.Count == 0)
                {
                    exist = false;
                }
            }
            catch (Exception ex)
            {
                Log.Error("An error occurred while checking test set existence in the database. ", ex);
                throw new Exception("Failed to check for test set existence");
            }

            Log.Info("CheckTestSetExistence() finished");

            return exist;
        }


        async public static Task<List<String>> GetAllTestSet()
        {
            Log.Info("GetAllTestSet() started");
            List<String> testSet = new List<string>();

            try
            {
                var collection = _database.GetCollection<BsonDocument>("test_set");
                var filter = new BsonDocument();
                using (var cursor = await collection.FindAsync(filter).ConfigureAwait(false))
                {
                    while (cursor.MoveNextAsync().Result)
                    {
                        var batch = cursor.Current;
                        foreach (var document in batch)
                        {
                            testSet.Add(document.GetValue("name").AsString);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error("An error occurred while getting all test set in the database. ", ex);
            }

            Log.Info("GetAllTestSet() finished");

            return testSet;
        }


        async public static Task<Boolean> DeleteTestSet(string name)
        {
            Log.Info("DeleteTestSet() started");
            Boolean result = true;

            try
            {
                var collection = _database.GetCollection<BsonDocument>("test_cases");
                var filter = Builders<BsonDocument>.Filter.Eq("test_set", name);
                await collection.DeleteManyAsync(filter).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Log.Error("An error occurred while deleting test cases of a test set.", ex);
                throw new Exception("Failed to delete all test cases of the test set in the database.");
            }

            try
            {
                var collection = _database.GetCollection<BsonDocument>("test_set");
                var filter = Builders<BsonDocument>.Filter.Eq("name", name);
                await collection.DeleteOneAsync(filter).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Log.Error("An error occurred while deleting test set", ex);
                result = false;
            }

            Log.Info("DeleteTestTest() finished");
            return result;
        }


        async public static Task<List<TestCase>> GetTestCasesByTestSet(string testSet)
        {
            Log.Info("GetTestCasesByTestSet() started");

            List<TestCase> testCases = new List<TestCase>();

            try
            {
                var collection = _database.GetCollection<BsonDocument>("test_cases");
                var filter = Builders<BsonDocument>.Filter.Eq("test_set", testSet);
                var result = await collection.Find(filter).ToListAsync().ConfigureAwait(false);

                List<BsonDocument> testCasesDocument = result.ToList<BsonDocument>();
                List<string> subjectDynamicAttributes = new List<string>();

                foreach (BsonDocument document in testCasesDocument)
                {
                    string testCaseName = document.GetValue("name").AsString;
                    TargetSystem targetSystem = (TargetSystem)document.GetValue("target_system").AsInt32;
                    Decision expectedResult = (Decision)document.GetValue("expected_result").AsInt32;
                    PolicyType policyType = (PolicyType)document.GetValue("policy_type").AsInt32;
                    string action = document.GetValue("action").AsString;

                    //get subject
                    BsonDocument bsonSubject = document.GetValue("subject").AsBsonDocument;

                    subjectDynamicAttributes.Clear();
                    BsonArray bsonSubjectAttributes = bsonSubject.GetValue("subject_dynamic_attributes").AsBsonArray;
                    foreach (BsonValue value in bsonSubjectAttributes.Values)
                    {
                        subjectDynamicAttributes.Add(value.AsString);
                    }

                    Subject subject = new Subject(bsonSubject.GetValue("user_name").AsString, bsonSubject.GetValue("windows_sid").AsString,
                        bsonSubject.GetValue("application_name").AsString, bsonSubject.GetValue("ip_address").AsString, subjectDynamicAttributes);

                    //get from resource
                    BsonDocument bsonFromResource = document.GetValue("from_resource").AsBsonDocument;

                    List<string> fromResourceDynamicAttributes = new List<string>();
                    BsonArray bsonFromResourceAttributes = bsonFromResource.GetValue("resource_dynamic_attributes").AsBsonArray;
                    foreach (BsonValue value in bsonFromResourceAttributes.Values)
                    {
                        fromResourceDynamicAttributes.Add(value.AsString);
                    }

                    Resource fromResource = new Resource(bsonFromResource.GetValue("resource_name").AsString, fromResourceDynamicAttributes);

                    //get to resource
                    BsonDocument bsonToResource = document.GetValue("to_resource").AsBsonDocument;

                    List<string> toResourceDynamicAttributes = new List<string>();
                    BsonArray bsonToResourceAttributes = bsonFromResource.GetValue("resource_dynamic_attributes").AsBsonArray;
                    foreach (BsonValue value in bsonToResourceAttributes.Values)
                    {
                        toResourceDynamicAttributes.Add(value.AsString);
                    }

                    Resource toResource = new Resource(bsonToResource.GetValue("resource_name").AsString, toResourceDynamicAttributes);

                    //get recipients
                    List<Subject> recipients = new List<Subject>();
                    BsonArray bsonRecipients = document.GetValue("recipients").AsBsonArray;
                    List<string> recipientAttributes = new List<string>();
                    foreach (BsonValue value in bsonRecipients)
                    {
                        BsonDocument bsonRecipient = value.AsBsonDocument;
                        recipientAttributes.Clear();
                        BsonArray bsonRepAttributes = bsonRecipient.GetValue("subject_dynamic_attributes").AsBsonArray;
                        foreach (BsonValue attr in bsonRepAttributes.Values)
                        {
                            recipientAttributes.Add(value.AsString);
                        }

                        recipients.Add(new Subject(bsonRecipient.GetValue("user_name").AsString, bsonRecipient.GetValue("windows_sid").AsString,
                        bsonRecipient.GetValue("application_name").AsString, bsonRecipient.GetValue("ip_address").AsString, recipientAttributes));
                    }

                    //get email values
                    string emailSubject = document.GetValue("email_subject").AsString;
                    string emailBody = document.GetValue("email_body").AsString;


                    TestCase testCase = new TestCase(testCaseName, testSet, targetSystem, expectedResult, policyType, subject,
                        action, fromResource, toResource, recipients, emailSubject, emailBody);

                    testCases.Add(testCase);
                }
            }
            catch (Exception ex)
            {
                Log.Error("An error occurred while getting test cases by test set in the database. ", ex);
            }

            Log.Info("GetTestCasesByTestSet() finihsed");

            return testCases;
        }

        async public static Task<List<string>> GetTestCaseNamesByTestSet(string testSet)
        {
            Log.Info("GetTestCaseNamesByTestSet() started");

            List<string> testCases = new List<string>();

            try
            {
                var collection = _database.GetCollection<BsonDocument>("test_cases");
                var filter = Builders<BsonDocument>.Filter.Eq("test_set", testSet);
                var projection = Builders<BsonDocument>.Projection.Include("name");
                var result = await collection.Find(filter).Project(projection).ToListAsync().ConfigureAwait(false);

                List<BsonDocument> testCasesDocument = result.ToList<BsonDocument>();

                foreach (BsonDocument document in testCasesDocument)
                {
                    string testCaseName = document.GetValue("name").AsString;
                    testCases.Add(testCaseName);
                }
            }
            catch (Exception ex)
            {
                Log.Error("An error occurred while getting test case names by test set in the database. ", ex);
            }

            Log.Info("GetTestCaseNamesByTestSet() finihsed");

            return testCases;
        }
    }

}

