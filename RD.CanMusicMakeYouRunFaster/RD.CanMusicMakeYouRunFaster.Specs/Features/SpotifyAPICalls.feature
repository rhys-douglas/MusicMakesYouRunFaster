Feature: Spotify API Calls

Background:
Given a list of users
| user      |
| User1 |

@MVP-0-Add-Spotify-API-Call
Scenario Outline: Get User's listening history
	Given a user <user>
	When the user's recently played history is requested
	Then the user's recently played history is produced