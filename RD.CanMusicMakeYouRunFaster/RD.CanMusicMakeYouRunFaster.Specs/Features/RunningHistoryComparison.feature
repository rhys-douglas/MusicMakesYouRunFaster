Feature: Comparison between running and listening history

Background:
Given a list of users
| user      |
| User1		|

Given a list of running history
| user  | Activity Name                           | Time of activity start | Elapsed Time of Activity (s)  | Activity Id |
| User1 | Cardiff Friday Morning Run			  | 15/02/2021 15:30:00	   | 4410						   | 1			 |
| User1 | Oxford Half Marathon					  | 14/02/2021 12:40:01	   | 3600						   | 2			 |
| User1 | Roath Lake Run						  | 13/02/2021 15:30:59    | 4410						   | 3			 |
| User1 | Late Night Run						  | 10/02/2021 00:05:00    | 1280						   | 4			 |
| User1 | Test Run								  | 01/01/2021 23:59:59    | 100						   | 5			 |

Given a list of listening history
| user  | Song name                           | Time of listening   |
| User1 | The Chain - 2004 Remaster           | 15/02/2021 15:45:30 |
| User1 | I Want To Break Free - Single Remix | 15/02/2021 15:40:01 |
| User1 | Good Vibrations - Remastered        | 15/02/2021 15:30:59 |
| User1 | Dreams - 2004 Remaster              | 15/02/2021 00:05:00 |
| User1 | Stayin Alive                        | 14/02/2021 23:59:59 |


@MVP-5-Single-Date-Comparison
Scenario Outline: Get User's Running History
	Given a user <user>
	And their running history
	And their listening history
	When the comparison between running and listening history is made
	Then the user's top tracks for running faster are produced.