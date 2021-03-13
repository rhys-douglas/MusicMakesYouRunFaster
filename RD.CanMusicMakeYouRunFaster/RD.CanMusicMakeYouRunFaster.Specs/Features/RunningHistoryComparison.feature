Feature: Comparison between running and listening history

Background:
Given a list of users
| user      |
| User1		|

Given a list of running history
| user  | Activity Name                           | Time of activity start | Elapsed Time of Activity (s)  | Activity Id | Average Pace (m/s) |
| User1 | Cardiff Friday Morning Run			  | 15/03/2021 12:00:00	   | 4410						   | 1			 | 4.5				  |
| User1 | Oxford Half Marathon					  | 14/03/2021 08:00:00	   | 9000						   | 2			 | 4.6                |
| User1 | Roath Lake Midnight Run				  | 13/03/2021 23:39:59    | 4410						   | 3			 | 4.2				  |
| User1 | Late Night Run						  | 10/03/2021 00:05:00    | 1280						   | 4			 | 1.6				  |
| User1 | Test Run								  | 01/01/2021 23:59:59    | 60							   | 5			 | 0.0				  |  

Given a list of listening history
| user  | Song name                           | Time of listening   |
| User1 | The Chain - 2004 Remaster           | 15/03/2021 12:00:05 |
| User1 | I Want To Break Free - Single Remix | 15/03/2021 12:03:30 |
| User1 | Good Vibrations - Remastered        | 15/03/2021 12:04:59 |
| User1 | Dreams - 2004 Remaster              | 15/03/2021 12:05:30 |
| User1 | Stayin Alive                        | 15/03/2021 12:07:20 |
| User1 | Junk Song                           | 15/03/2021 23:59:20 |
| User1 | Riptide	                          | 14/03/2021 08:00:01 |
| User1 | Can't Hold Us                       | 14/03/2021 08:03:30 |
| User1 | Starboy		                      | 14/03/2021 08:09:40 |
| User1 | Beautiful Day	                      | 14/03/2021 08:30:00 |
| User1 | Starman							  | 13/03/2021 00:02:00 |
| User1 | Kickstarts						  | 13/03/2021 00:05:00 |
| User1 | Sugar								  | 10/03/2021 00:05:01 |




@MVP-5-Single-Date-Comparison
Scenario: Compare Listening And Running History
	Given a user <user>
	And their running history
	And their listening history
	When the user's recent running history is requested
	And the user's recently played history based on their running history is requested
	And the comparison between running and listening history is made
	Then the user's top tracks for running faster are produced
	|Song name							|
	|The Chain - 2004 Remaster			|
	|I Want To Break Free - Single Remix|
	|Good Vibrations - Remastered		|
	|Dreams - 2004 Remaster				|
	|Stayin Alive						|

@EDF-0-DateRange-Comparison
Scenario: Compare Listening and Running History with date range
Given a user <user>
	And their running history
	And their listening history
	When the user's recent running history is requested
	And the user's recently played history based on their running history is requested
	And the comparison between running and listening history is made using a specified date range
	Then the user's top tracks for running faster are produced
	|Song name							  |
	| Riptide	                          |
	| Can't Hold Us                       |
	| Starboy		                      |
	| Beautiful Day	                      |