using Newtonsoft.Json;
using Reqnroll;
using System.Reflection;
using ZeissInterviewTask.ApiFramework;
using ZeissInterviewTask.ModalClasses;
using ZeissInterviewTask.Utility;

namespace ZeissInterviewTask.StepDefinition
{
    [Binding]
    public sealed class AuthenticationSteps
    {
        private readonly ApiClient _apiClient;
        private readonly ScenarioContext _scenarioContext;

        public AuthenticationSteps(ApiClient apiClient,ScenarioContext scenarioContext )
        {
            
            _apiClient = apiClient;
            _scenarioContext = scenarioContext;
        }

        [Given("an authentication api")]
        public void GivenAnAuthenticationApi()
        {
           _apiClient.ApiUrl = ConfigProperties.AuthenticationAPI;
        }

        [When("the user enters {string} and {string}")]
        public void WhenTheUserEntersAnd(string username , string password)
        {
            
            var requestPayload = new LoginRequest
            {
                Username = username == "null" ? null : username == "<empty>" ? "" : username,
                Password = password == "null" ? null : password == "<empty>" ? "" : password,
            };

            _apiClient.AddRequestbody(JsonConvert.SerializeObject(requestPayload));
            var response = _apiClient.PostAsyncRequest();
            _scenarioContext.Add("response", response);
        }
        [Then("the response status code should be {int}")]
        public void ThenTheResponseStatusCodeShouldBe(int statusCode)
        {
            var result = _scenarioContext["response"] as ApiResponseWithHeaders;
            Assert.That((int)result.StatusCode == statusCode);
        }
      
        [Then("the response body should be {string}, {string},{string}")]
        public void ThenTheResponseBodyShouldBe(bool successMessage, string userID, string username)
        {
            var expected = new ResponseModal
            {
                Success = successMessage,
                UserId = int.Parse(userID),
                Username = username
            };
            var result = _scenarioContext["response"] as ApiResponseWithHeaders;
            var actual = JsonConvert.DeserializeObject<ResponseModal>(result.Content);
            Assert.That(actual.Success == expected.Success);
            Assert.That(actual.UserId == expected.UserId);
            Assert.That(actual.Username == expected.Username);
        }

        [Then("the response should be {string} and {string}")]
        public void ThenTheResponseShouldBeAnd(bool successMessage, string errorMessage)
        {
            var expected = new ResponseModal
            {
                Success = successMessage,
                ErrorMessage = errorMessage
            };

            var result = _scenarioContext["response"] as ApiResponseWithHeaders;
            var actual = JsonConvert.DeserializeObject<ResponseModal>(result.Content);
            Assert.That(actual.Success == expected.Success);
            Assert.That(actual.ErrorMessage == expected.ErrorMessage);
        }


        #region AdditonalScenarios
        [Given("the user has attempted {int} unsuccessfull login")]
        public void GivenTheUserHasAttemptedUnsuccessfullLogin(int unsuccessfullLogin)
        {
           //  throw new PendingStepException();
        }

        [When("the user tries to login for one more time")]
        public void WhenTheUserTriesToLoginForOneMoreTime()
        {
           // throw new PendingStepException();
        }

        [Then("the response should have")]
        public void ThenTheResponseShouldHave(DataTable dataTable)
        {
           // throw new PendingStepException();
        }

        [Given("the user has reset the password")]
        public void GivenTheUserHasResetThePassword()
        {
           // throw new PendingStepException();
        }


        [When("the user enters {string} and new {string}")]
        public void WhenTheUserEntersAndNew(string userName, string password)
        {
          //  throw new PendingStepException();
        }
        [Given("the user's password has expired")]
        public void GivenTheUsersPasswordHasExpired()
        {
            //throw new PendingStepException();
        }
        #endregion

    }
}