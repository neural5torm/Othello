﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Othello.SpecTests
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class CreateOthelloBoardFeature : object, Xunit.IClassFixture<CreateOthelloBoardFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "CreateOthelloBoard.feature"
#line hidden
        
        public CreateOthelloBoardFeature(CreateOthelloBoardFeature.FixtureData fixtureData, Othello_SpecTests_XUnitAssemblyFixture assemblyFixture, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "", "Create Othello board", null, ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void TestInitialize()
        {
        }
        
        public virtual void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        void System.IDisposable.Dispose()
        {
            this.TestTearDown();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Creating a standard initial Othello board should display an 8x8 grid of empty squ" +
            "ares except for its 2x2 center containing the initial black and white discs")]
        [Xunit.TraitAttribute("FeatureTitle", "Create Othello board")]
        [Xunit.TraitAttribute("Description", "Creating a standard initial Othello board should display an 8x8 grid of empty squ" +
            "ares except for its 2x2 center containing the initial black and white discs")]
        public virtual void CreatingAStandardInitialOthelloBoardShouldDisplayAn8X8GridOfEmptySquaresExceptForIts2X2CenterContainingTheInitialBlackAndWhiteDiscs()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Creating a standard initial Othello board should display an 8x8 grid of empty squ" +
                    "ares except for its 2x2 center containing the initial black and white discs", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 3
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
#line 4
 testRunner.When("I create an initial Othello board", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
                TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                            "",
                            "a",
                            "b",
                            "c",
                            "d",
                            "e",
                            "f",
                            "g",
                            "h"});
                table1.AddRow(new string[] {
                            "1",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            ""});
                table1.AddRow(new string[] {
                            "2",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            ""});
                table1.AddRow(new string[] {
                            "3",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            ""});
                table1.AddRow(new string[] {
                            "4",
                            "",
                            "",
                            "",
                            "W",
                            "B",
                            "",
                            "",
                            ""});
                table1.AddRow(new string[] {
                            "5",
                            "",
                            "",
                            "",
                            "B",
                            "W",
                            "",
                            "",
                            ""});
                table1.AddRow(new string[] {
                            "6",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            ""});
                table1.AddRow(new string[] {
                            "7",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            ""});
                table1.AddRow(new string[] {
                            "8",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            ""});
#line 5
 testRunner.Then("the board should look like", ((string)(null)), table1, "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Creating an initial 4x4 Othello board should display a 4x4 grid of empty squares " +
            "except for its 2x2 center containing the initial black and white discs")]
        [Xunit.TraitAttribute("FeatureTitle", "Create Othello board")]
        [Xunit.TraitAttribute("Description", "Creating an initial 4x4 Othello board should display a 4x4 grid of empty squares " +
            "except for its 2x2 center containing the initial black and white discs")]
        public virtual void CreatingAnInitial4X4OthelloBoardShouldDisplayA4X4GridOfEmptySquaresExceptForIts2X2CenterContainingTheInitialBlackAndWhiteDiscs()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Creating an initial 4x4 Othello board should display a 4x4 grid of empty squares " +
                    "except for its 2x2 center containing the initial black and white discs", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 16
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
#line 17
 testRunner.When("I create an initial 4x4 Othello board", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
                TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                            "",
                            "a",
                            "b",
                            "c",
                            "d"});
                table2.AddRow(new string[] {
                            "1",
                            "",
                            "",
                            "",
                            ""});
                table2.AddRow(new string[] {
                            "2",
                            "",
                            "W",
                            "B",
                            ""});
                table2.AddRow(new string[] {
                            "3",
                            "",
                            "B",
                            "W",
                            ""});
                table2.AddRow(new string[] {
                            "4",
                            "",
                            "",
                            "",
                            ""});
#line 18
 testRunner.Then("the board should look like", ((string)(null)), table2, "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Creating an initial 2x2 Othello board should display a 2x2 grid containing the in" +
            "itial black and white discs")]
        [Xunit.TraitAttribute("FeatureTitle", "Create Othello board")]
        [Xunit.TraitAttribute("Description", "Creating an initial 2x2 Othello board should display a 2x2 grid containing the in" +
            "itial black and white discs")]
        public virtual void CreatingAnInitial2X2OthelloBoardShouldDisplayA2X2GridContainingTheInitialBlackAndWhiteDiscs()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Creating an initial 2x2 Othello board should display a 2x2 grid containing the in" +
                    "itial black and white discs", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 25
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
#line 26
 testRunner.When("I create an initial 2x2 Othello board", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
                TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                            "",
                            "a",
                            "b"});
                table3.AddRow(new string[] {
                            "1",
                            "W",
                            "B"});
                table3.AddRow(new string[] {
                            "2",
                            "B",
                            "W"});
#line 27
 testRunner.Then("the board should look like", ((string)(null)), table3, "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Creating a 10x10 initial Othello board should display a 10x10 grid of empty squar" +
            "es except for its 2x2 center containing the initial black and white discs")]
        [Xunit.TraitAttribute("FeatureTitle", "Create Othello board")]
        [Xunit.TraitAttribute("Description", "Creating a 10x10 initial Othello board should display a 10x10 grid of empty squar" +
            "es except for its 2x2 center containing the initial black and white discs")]
        public virtual void CreatingA10X10InitialOthelloBoardShouldDisplayA10X10GridOfEmptySquaresExceptForIts2X2CenterContainingTheInitialBlackAndWhiteDiscs()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Creating a 10x10 initial Othello board should display a 10x10 grid of empty squar" +
                    "es except for its 2x2 center containing the initial black and white discs", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 32
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
#line 33
 testRunner.When("I create an initial 10x10 Othello board", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
                TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                            "",
                            "a",
                            "b",
                            "c",
                            "d",
                            "e",
                            "f",
                            "g",
                            "h",
                            "i",
                            "j"});
                table4.AddRow(new string[] {
                            "1",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            ""});
                table4.AddRow(new string[] {
                            "2",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            ""});
                table4.AddRow(new string[] {
                            "3",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            ""});
                table4.AddRow(new string[] {
                            "4",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            ""});
                table4.AddRow(new string[] {
                            "5",
                            "",
                            "",
                            "",
                            "",
                            "W",
                            "B",
                            "",
                            "",
                            "",
                            ""});
                table4.AddRow(new string[] {
                            "6",
                            "",
                            "",
                            "",
                            "",
                            "B",
                            "W",
                            "",
                            "",
                            "",
                            ""});
                table4.AddRow(new string[] {
                            "7",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            ""});
                table4.AddRow(new string[] {
                            "8",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            ""});
                table4.AddRow(new string[] {
                            "9",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            ""});
                table4.AddRow(new string[] {
                            "10",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            ""});
#line 34
 testRunner.Then("the board should look like", ((string)(null)), table4, "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                CreateOthelloBoardFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                CreateOthelloBoardFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
