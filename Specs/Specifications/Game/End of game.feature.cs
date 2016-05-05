﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.0.0.0
//      SpecFlow Generator Version:2.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Specs.Specifications.Game
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.0.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("End of game")]
    public partial class EndOfGameFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "End of game.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-EN"), "End of game", null, ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.TestFixtureTearDownAttribute()]
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
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("The village wins if all action of the ritual are done before the due date")]
        [NUnit.Framework.IgnoreAttribute("Ignored scenario")]
        [NUnit.Framework.CategoryAttribute("US004")]
        public virtual void TheVillageWinsIfAllActionOfTheRitualAreDoneBeforeTheDueDate()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("The village wins if all action of the ritual are done before the due date", new string[] {
                        "US004",
                        "ignore"});
#line 5
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Action",
                        "Workload"});
            table1.AddRow(new string[] {
                        "Hunt an elephant",
                        "1"});
#line 8
 testRunner.Given("a ritual named \"Crocto\" with the following actions:", ((string)(null)), table1, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Villager"});
            table2.AddRow(new string[] {
                        "Alice"});
#line 12
 testRunner.And("a village named \"Podunk\" inhabited by", ((string)(null)), table2, "And ");
#line 16
 testRunner.And("the village \"Podunk\" must perform the \"Crocto\" ritual before the 13 day ends", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "Villager",
                        "Action"});
            table3.AddRow(new string[] {
                        "Alice",
                        "Hunt an elephant"});
#line 18
 testRunner.When("the \"Podunk\" village plan for the day is:", ((string)(null)), table3, "When ");
#line 22
 testRunner.Then("the \"Podunk\" village is safe!", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("The village is eaten if the ritual is not performed before the due date")]
        [NUnit.Framework.IgnoreAttribute("Ignored scenario")]
        [NUnit.Framework.CategoryAttribute("US004")]
        public virtual void TheVillageIsEatenIfTheRitualIsNotPerformedBeforeTheDueDate()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("The village is eaten if the ritual is not performed before the due date", new string[] {
                        "US004",
                        "ignore"});
#line 27
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "Action",
                        "Workload"});
            table4.AddRow(new string[] {
                        "Hunting an elephant",
                        "2"});
#line 30
 testRunner.Given("a ritual named \"Crocto\" with the following actions:", ((string)(null)), table4, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "Villager"});
            table5.AddRow(new string[] {
                        "Alice"});
#line 34
 testRunner.And("a village named \"Podunk\" inhabited by", ((string)(null)), table5, "And ");
#line 38
 testRunner.And("the village \"Podunk\" must perform the \"Crocto\" before the 1 day ends", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "Villager",
                        "Action"});
            table6.AddRow(new string[] {
                        "Alice",
                        "Hunting an elephant"});
#line 40
 testRunner.When("the \"Podunk\" village plan for the day is:", ((string)(null)), table6, "When ");
#line 44
 testRunner.Then("the whole \"Podunk\" village is eaten by the Crocto", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion