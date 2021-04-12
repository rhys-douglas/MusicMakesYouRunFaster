Feature: Spotify API Calls

Background:
Given a list of users
| user      |
| User1		|

Given a list of Spotify listening history
| user  | Song name                           | Time of listening   |
| User1 | The Chain - 2004 Remaster           | 15/02/2021 15:45:30 |
| User1 | I Want To Break Free - Single Remix | 15/02/2021 15:40:01 |
| User1 | Good Vibrations - Remastered        | 15/02/2021 15:30:59 |
| User1 | Dreams - 2004 Remaster              | 15/02/2021 00:05:00 |
| User1 | Stayin Alive                        | 14/02/2021 23:59:59 |


@MVP-0-Add-Spotify-API-Call
Scenario Outline: Get User's Spotify listening history
	Given a user <user>
	And their Spotify listening history 
	When the user's Spotify recently played history is requested
	Then the user's Spotify recently played history is produced