Feature: Strava API Calls

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


@MVP-4-Add-Strava-API-Call
Scenario Outline: Get User's Running History
	Given a user <user>
	And their running history 
	When the user's recent running history is requested
	Then the user's recent running history is produced