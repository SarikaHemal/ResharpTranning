Feature: PostProfileFeature
	Test POST operation using restassurance liabrary

Background: 
	Given I perform authinetication of user with following detail
	| email				| password |
	|nilson@email.com   | nilson   |

@mytag
Scenario: Varify post operation for profile
	Given I perform POST operation for "posts/{profileNo}/profile" with body
	| name | profile |
	| Sams  | 13      |
	Then I should see the "name" name as "Sams"