using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using COCOMOCalculator.BL.Services;
using System;
using COCOMOCalculator.BL.Models;
using System.Collections.Generic;
using COCOMOCalculator.BL.Models.Attributes.SecondCocomo;
using COCOMOCalculator.BL.Models.Args;

namespace Test
{
    [TestClass]
    public class NamingTest
    {
        [TestMethod]
        public void ProjectTypeNamesInBasicFileEqualsProjectTypeNamesInProgram()
        {
            var dict = FileManager.FillBasicProjectTypeDictionary();

            var enums = Enum.GetValues(typeof(ProjectType)).Cast<ProjectType>().ToHashSet();
            enums.Remove(ProjectType.Undefined);
                
            var keys = dict.Keys.ToHashSet();

            Assert.IsTrue(keys.SetEquals(enums));
        }

        [TestMethod]
        public void ProjectTypeNamesInIntemediateFileEqualsProjectTypeNamesInProgram()
        {
            var dict = FileManager.FillIntermediateProjectTypeDictionary();

            var enums = Enum.GetValues(typeof(ProjectType)).Cast<ProjectType>().ToHashSet();
            enums.Remove(ProjectType.Undefined);

            var keys = dict.Keys.ToHashSet();

            Assert.IsTrue(keys.SetEquals(enums));
        }

        [TestMethod]
        public void CostAttributeNamesInFileEqualsCostAttributeNamesInProgram()
        {
            var dict = FileManager.FillCostAttributesDictionary();

            var keys = dict.Keys.ToHashSet();

            var props = IncludedProperties(typeof(IntermediateCalculationArgs));

            Assert.IsTrue(keys.IsProperSubsetOf(props));
        }

        [TestMethod]
        public void ScaleFactorNamesInFileEqualsScaleFactorNamesInProgram()
        {
            var dict = FileManager.FillScaleFactorDictionary();

            var keys = dict.Keys.ToHashSet();

            var props = IncludedProperties(typeof(ScaleFactorsAttributes));

            Assert.IsTrue(keys.IsSubsetOf(props));
        }

        [TestMethod]
        public void EarlyDesignEffortMultiplierNamesInFileEqualsEarlyDesignEffortMultiplierNamesInProgram()
        {
            var dict = FileManager.FillEarlyDesignEffortMultiplierDictionary();

            var keys = dict.Keys.ToHashSet();

            var props = IncludedProperties(typeof(EarlyDesignCalculationArgs));

            Assert.IsTrue(keys.IsSubsetOf(props));
        }

        [TestMethod]
        public void PostArchitectureEffortMultiplierNamesInFileEqualsPostArchitectureEffortMultiplierNamesInProgram()
        {
            var dict = FileManager.FillPostArchitectureEffortMultiplierDictionary();

            var keys = dict.Keys.ToHashSet();

            var props = IncludedProperties(typeof(PostArchitectureCalculationArgs));

            Assert.IsTrue(keys.IsSubsetOf(props));
        }

        private HashSet<string> IncludedProperties(Type type)
        {
            var properties = type.GetProperties();
            HashSet<string> allPropertiesName = new HashSet<string>();
            foreach (var currentProperty in properties)
            {
                var typeOfCurrentProperty = currentProperty.PropertyType;
                var propertiesOfCurrentProperty = typeOfCurrentProperty.GetProperties();
                if (propertiesOfCurrentProperty.Count() > 0)
                {
                    allPropertiesName.UnionWith(IncludedProperties(typeOfCurrentProperty));
                }
                else
                {
                    allPropertiesName.Add(currentProperty.Name);
                }
            }
            return allPropertiesName;
        }
    }
}
