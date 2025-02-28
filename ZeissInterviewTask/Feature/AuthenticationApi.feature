Feature: Authentication Api

Authentication Api validates a user login

@ValidCredentials
Scenario Outline: User Logins with valid credentials
	Given an authentication api
	When the user enters "<UserName>" and "<Password>"
	Then the response status code should be 200
	And the response body should be "<SuccessMessage>", "<userId>","<username>"
Examples:
	| UserName | Password | Code | SuccessMessage | userId |
	| John     | Doe      | 200  | true           | 1      |
	| Jane     | Doe      | 200  | true           | 2      |

@InValidCredentials
Scenario Outline: User logins with invalid credentials
	Given an authentication api
	When the user enters "<UserName>" and "<Password>"
	Then the response status code should be 401
	And the response should be "<SuccessMessage>" and "<ErrorMessage>"
Examples:
	| Description                          | UserName | Password | SuccessMessage | ErrorMessage                  |
	| Case sensitivity                     | john     | doe      | false          | Invalid username or password. |
	| special characters                   | J@hn     | Do*      | false          | Invalid username or password. |
	| Invalid password                     | John     | 123      | false          | Invalid username or password. |
	| Invalid Username                     | Sam      | Doe      | false          | Invalid username or password. |
	| Password is null                     | John     | null     | false          | Invalid username or password. |
	| Username is null                     | null     | Password | false          | Invalid username or password. |
	| Both Password and username are null  | null     | null     | false          | Invalid username or password. |
	| Password is empty                    | John     | <empty>  | false          | Invalid username or password. |
	| Username is empty                    | <empty>  | Password | false          | Invalid username or password. |
	| Both Password and username are empty | <empty>  | <empty>  | false          | Invalid username or password. |
	
@AdditonalScenarios
Scenario: Account is blocked after 3 unsuccessfull login attempts
	Given the user has attempted 3 unsuccessfull login
	When  the user enters "UserName" and "Password"
	Then the response status code should be 429
	And the response should have
		| ErrorMessage                               |
		| User is blocked to login for next 24 hours |
@AdditonalScenarios
Scenario: Validate user is able to login after password reset
 Given the user has reset the password
 When the user enters "John" and new "DoeDoe"
 Then the response status code should be 200

 @AdditonalScenarios
Scenario: Validate user tries to login using expired password
 Given the user's password has expired
 When the user enters "John" and "Doe"
 Then the response status code should be 401


