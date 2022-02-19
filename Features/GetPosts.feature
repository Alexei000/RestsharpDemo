Feature: GetPosts
	Test GET posts operation with RestSharp.Net

@tag1
Scenario: Verify author of post 1
	Given I perform GET operation for "posts/{postid}"
	When I perform operation or post "1"
	Then I should see the "author" name as "Karthik KK"
