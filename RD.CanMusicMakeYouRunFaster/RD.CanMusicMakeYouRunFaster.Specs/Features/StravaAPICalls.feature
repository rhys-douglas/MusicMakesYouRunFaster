﻿Feature: Strava API Calls

Background:
Given a list of users
| user      |
| User1		|

Given a list of Strava running history
| user  | Activity Name                           | Time of activity start | Elapsed Time of Activity (s)  | Activity Id | Average Pace (m/s) |
| User1 | Cardiff Friday Morning Run			  | 15/03/2021 12:00:00	   | 4410						   | 1			 | 4.5				  |
| User1 | Oxford Half Marathon					  | 14/03/2021 08:00:00	   | 9000						   | 2			 | 4.6                |
| User1 | Roath Lake Midnight Run				  | 13/03/2021 23:39:59    | 4410						   | 3			 | 4.2				  |
| User1 | Late Night Run						  | 10/03/2021 00:05:00    | 1280						   | 4			 | 1.6				  |
| User1 | Test Run								  | 01/01/2021 23:59:59    | 60							   | 5			 | 0.0				  | 

@MVP-4-Add-Strava-API-Call
Scenario Outline: Get User's Strava Running History
	Given a user <user>
	And their Strava running history 
	When the user's recent Strava running history is requested
	Then the user's recent Strava running history is produced