﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.7.0.0
//      SpecFlow Generator Version:3.7.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace RD.CanMusicMakeYouRunFaster.Specs.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.7.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Comparison between running and listening history")]
    public partial class ComparisonBetweenRunningAndListeningHistoryFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
#line 1 "RunningHistoryComparison.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "Comparison between running and listening history", null, ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void FeatureBackground()
        {
#line 3
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "user"});
            table5.AddRow(new string[] {
                        "User1"});
#line 4
testRunner.Given("a list of users", ((string)(null)), table5, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "user",
                        "Activity Name",
                        "Time of activity start",
                        "Elapsed Time of Activity (s)",
                        "Activity Id",
                        "Average Pace (m/s)"});
            table6.AddRow(new string[] {
                        "User1",
                        "Cardiff Friday Morning Run",
                        "15/03/2021 12:00:00",
                        "4410",
                        "1",
                        "4.5"});
            table6.AddRow(new string[] {
                        "User1",
                        "Oxford Half Marathon",
                        "14/03/2021 08:00:00",
                        "9000",
                        "2",
                        "4.6"});
            table6.AddRow(new string[] {
                        "User1",
                        "Roath Lake Midnight Run",
                        "13/03/2021 23:39:59",
                        "4410",
                        "3",
                        "4.2"});
            table6.AddRow(new string[] {
                        "User1",
                        "Late Night Run",
                        "10/03/2021 00:05:00",
                        "1280",
                        "4",
                        "1.6"});
            table6.AddRow(new string[] {
                        "User1",
                        "Test Run",
                        "01/01/2021 23:59:59",
                        "60",
                        "5",
                        "0.0"});
#line 8
testRunner.Given("a list of Strava running history", ((string)(null)), table6, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "user",
                        "Activity Name",
                        "Time of activity start",
                        "Elapsed Time of Activity (s)",
                        "Activity Id",
                        "Average Pace (m/s)"});
            table7.AddRow(new string[] {
                        "User1",
                        "1% Better test",
                        "25/03/2021 12:00:00",
                        "4410",
                        "1",
                        "6"});
            table7.AddRow(new string[] {
                        "User1",
                        "Cardiff Half Marathon",
                        "23/03/2021 08:00:00",
                        "9500",
                        "2",
                        "4.6"});
            table7.AddRow(new string[] {
                        "User1",
                        "Bute Midnight Run",
                        "22/03/2021 23:39:59",
                        "3700",
                        "3",
                        "3.9"});
            table7.AddRow(new string[] {
                        "User1",
                        "Late Night Run 2",
                        "21/03/2021 00:05:00",
                        "1280",
                        "4",
                        "1.6"});
            table7.AddRow(new string[] {
                        "User1",
                        "Oops",
                        "25/12/2020 23:59:59",
                        "60",
                        "5",
                        "0.0"});
#line 16
testRunner.Given("a list of FitBit running history", ((string)(null)), table7, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                        "user",
                        "Song name",
                        "Time of listening"});
            table8.AddRow(new string[] {
                        "User1",
                        "The Chain - 2004 Remaster",
                        "15/03/2021 12:00:05"});
            table8.AddRow(new string[] {
                        "User1",
                        "I Want To Break Free - Single Remix",
                        "15/03/2021 12:03:30"});
            table8.AddRow(new string[] {
                        "User1",
                        "Good Vibrations - Remastered",
                        "15/03/2021 12:04:59"});
            table8.AddRow(new string[] {
                        "User1",
                        "Dreams - 2004 Remaster",
                        "15/03/2021 12:05:30"});
            table8.AddRow(new string[] {
                        "User1",
                        "Stayin Alive",
                        "15/03/2021 12:07:20"});
            table8.AddRow(new string[] {
                        "User1",
                        "Junk Song",
                        "15/03/2021 23:59:20"});
            table8.AddRow(new string[] {
                        "User1",
                        "Riptide",
                        "14/03/2021 08:00:01"});
            table8.AddRow(new string[] {
                        "User1",
                        "Can\'t Hold Us",
                        "14/03/2021 08:03:30"});
            table8.AddRow(new string[] {
                        "User1",
                        "Starboy",
                        "14/03/2021 08:09:40"});
            table8.AddRow(new string[] {
                        "User1",
                        "Beautiful Day",
                        "14/03/2021 08:30:00"});
            table8.AddRow(new string[] {
                        "User1",
                        "Starman",
                        "13/03/2021 00:02:00"});
            table8.AddRow(new string[] {
                        "User1",
                        "Kickstarts",
                        "13/03/2021 00:05:00"});
            table8.AddRow(new string[] {
                        "User1",
                        "Sugar",
                        "10/03/2021 00:05:01"});
#line 24
testRunner.Given("a list of Spotify listening history", ((string)(null)), table8, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                        "user",
                        "Song name",
                        "Time of listening"});
            table9.AddRow(new string[] {
                        "User1",
                        "The Chain - 2004 Remaster",
                        "15/02/2021 15:45:30"});
            table9.AddRow(new string[] {
                        "User1",
                        "I Want To Break Free - Single Remix",
                        "15/02/2021 15:40:01"});
            table9.AddRow(new string[] {
                        "User1",
                        "Good Vibrations - Remastered",
                        "15/02/2021 15:30:59"});
            table9.AddRow(new string[] {
                        "User1",
                        "Dreams - 2004 Remaster",
                        "15/02/2021 00:05:00"});
            table9.AddRow(new string[] {
                        "User1",
                        "Stayin Alive",
                        "14/02/2021 23:59:59"});
            table9.AddRow(new string[] {
                        "User1",
                        "Superheroes",
                        "25/03/2021 12:00:05"});
            table9.AddRow(new string[] {
                        "User1",
                        "Stepping Stone",
                        "25/03/2021 12:03:30"});
#line 40
testRunner.Given("a list of Last.FM listening history", ((string)(null)), table9, "Given ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Compare Listening And Running History")]
        [NUnit.Framework.CategoryAttribute("MVP-5-Single-Date-Comparison")]
        public virtual void CompareListeningAndRunningHistory()
        {
            string[] tagsOfScenario = new string[] {
                    "MVP-5-Single-Date-Comparison"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Compare Listening And Running History", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 53
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 3
this.FeatureBackground();
#line hidden
#line 54
 testRunner.Given("a user <user>", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 55
 testRunner.And("their Strava running history", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 56
 testRunner.And("their Spotify listening history", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 57
 testRunner.When("the user\'s recent Strava running history is requested", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 58
 testRunner.And("the user\'s recently played history based on their running history is requested", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 59
 testRunner.And("the comparison between running and listening history is made", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table10 = new TechTalk.SpecFlow.Table(new string[] {
                            "Song name"});
                table10.AddRow(new string[] {
                            "The Chain - 2004 Remaster"});
                table10.AddRow(new string[] {
                            "I Want To Break Free - Single Remix"});
                table10.AddRow(new string[] {
                            "Good Vibrations - Remastered"});
                table10.AddRow(new string[] {
                            "Dreams - 2004 Remaster"});
                table10.AddRow(new string[] {
                            "Stayin Alive"});
#line 60
 testRunner.Then("the user\'s top tracks for running faster are produced", ((string)(null)), table10, "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Compare Listening and Running History with date range")]
        [NUnit.Framework.CategoryAttribute("EDF-0-DateRange-Comparison")]
        public virtual void CompareListeningAndRunningHistoryWithDateRange()
        {
            string[] tagsOfScenario = new string[] {
                    "EDF-0-DateRange-Comparison"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Compare Listening and Running History with date range", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 69
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 3
this.FeatureBackground();
#line hidden
#line 70
 testRunner.Given("a user <user>", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 71
 testRunner.And("their Strava running history", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 72
 testRunner.And("their Spotify listening history", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 73
 testRunner.When("the user\'s recent Strava running history is requested", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 74
 testRunner.And("the user\'s recently played history based on their running history is requested", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 75
 testRunner.And("the comparison between running and listening history is made using a specified da" +
                        "te range", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table11 = new TechTalk.SpecFlow.Table(new string[] {
                            "Song name"});
                table11.AddRow(new string[] {
                            "Riptide"});
                table11.AddRow(new string[] {
                            "Can\'t Hold Us"});
                table11.AddRow(new string[] {
                            "Starboy"});
                table11.AddRow(new string[] {
                            "Beautiful Day"});
#line 76
 testRunner.Then("the user\'s top tracks for running faster are produced", ((string)(null)), table11, "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Compare Listening and Running History on singular date with alternative data sour" +
            "ces")]
        [NUnit.Framework.CategoryAttribute("EDS-1-Multiple-Date-Source-Comparison")]
        public virtual void CompareListeningAndRunningHistoryOnSingularDateWithAlternativeDataSources()
        {
            string[] tagsOfScenario = new string[] {
                    "EDS-1-Multiple-Date-Source-Comparison"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Compare Listening and Running History on singular date with alternative data sour" +
                    "ces", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 84
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 3
this.FeatureBackground();
#line hidden
#line 85
testRunner.Given("a user <user>", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 86
 testRunner.And("their FitBit running history", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 87
 testRunner.And("their Last.FM listening history", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 88
 testRunner.When("the user\'s recent FitBit running history is requested", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 89
 testRunner.And("the user\'s recently played history based on their running history is requested", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 90
 testRunner.And("the comparison between running and listening history is made using a specified da" +
                        "te range", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table12 = new TechTalk.SpecFlow.Table(new string[] {
                            "Song name"});
                table12.AddRow(new string[] {
                            "Superheroes"});
                table12.AddRow(new string[] {
                            "Stepping Stone"});
#line 91
 testRunner.Then("the user\'s top tracks for running faster are produced", ((string)(null)), table12, "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Compare Listening and Running History on singular date AND multiple data sources." +
            "")]
        [NUnit.Framework.CategoryAttribute("EDS-1-Multiple-Date-Source-Comparison")]
        public virtual void CompareListeningAndRunningHistoryOnSingularDateANDMultipleDataSources_()
        {
            string[] tagsOfScenario = new string[] {
                    "EDS-1-Multiple-Date-Source-Comparison"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Compare Listening and Running History on singular date AND multiple data sources." +
                    "", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 98
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 3
this.FeatureBackground();
#line hidden
#line 99
testRunner.Given("a user <user>", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 100
 testRunner.And("their FitBit running history", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 101
 testRunner.And("their Strava running history", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 102
 testRunner.And("their Last.FM listening history", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 103
 testRunner.And("their Spotify listening history", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 104
 testRunner.When("the user\'s recent Strava running history is requested", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 105
 testRunner.When("the user\'s recent FitBit running history is requested", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 106
 testRunner.And("the user\'s recently played history based on their running history is requested us" +
                        "ing multiple data sources", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 107
 testRunner.And("the comparison between running and listening history is made", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table13 = new TechTalk.SpecFlow.Table(new string[] {
                            "Song name"});
                table13.AddRow(new string[] {
                            "Superheroes"});
                table13.AddRow(new string[] {
                            "Stepping Stone"});
#line 108
 testRunner.Then("the user\'s top tracks for running faster are produced", ((string)(null)), table13, "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Compare Listening and Running History with date range AND multiple data sources.")]
        [NUnit.Framework.CategoryAttribute("EDS-1-Multiple-Data-Source-Comparison")]
        public virtual void CompareListeningAndRunningHistoryWithDateRangeANDMultipleDataSources_()
        {
            string[] tagsOfScenario = new string[] {
                    "EDS-1-Multiple-Data-Source-Comparison"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Compare Listening and Running History with date range AND multiple data sources.", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 115
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 3
this.FeatureBackground();
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
