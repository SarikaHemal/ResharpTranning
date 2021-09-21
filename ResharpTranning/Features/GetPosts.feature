Feature: GetPosts
	Test GET posts operation with Restsharp.net

Background: 
	Given I perform authinetication of user with following detail
	| email				| password |
	|nilson@email.com   | nilson   |

Scenario: Verify author of the posts 1 
	Given I perform GET operation for "posts/{postid}"
	And I perform operation for post "1"
	Then I should see the "author" name as "Sarika"

Scenario: Verify author of the posts 5 
	Given I perform GET operation for "posts/{postid}"
	And I perform operation for post "5"
	Then I should see the "author" name as "Karthik KK"

Scenario: Verify author of the posts 9 
	Given I perform GET operation for "posts/{postid}"
	And I perform operation for post "9"
	Then I should see the "author" name as "Karthik KK"