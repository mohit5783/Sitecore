using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace GeneralKnowledge.Test.App.Tests
{
    /// <summary>
    /// This test evaluates the 
    /// </summary>
    public class XmlReadingTest : ITest
    {
        public string Name { get { return "XML Reading Test"; } }

        public void Run()
        {
            var xmlData = Resources.SamplePoints;

            // TODO: 
            // Determine for each parameter stored in the variable below, the average value, lowest and highest number.
            // Example output
            // parameter   LOW AVG MAX
            // temperature   x   y   z
            // pH            x   y   z
            // Chloride      x   y   z
            // Phosphate     x   y   z
            // Nitrate       x   y   z

            PrintOverview(xmlData);
        }

        private void PrintOverview(string xml)
        {
            samples objMeasure = new samples();
            objMeasure = (samples)new XmlSerializer(typeof(samples), new XmlRootAttribute("samples")).Deserialize(new StringReader(xml));
            List<Outputmatrix> outputmatrices = new List<Outputmatrix>();
            Console.WriteLine("Parameter".PadRight(15, ' ') + "Low".PadRight(10, ' ') + "Avg".PadRight(10, ' ') + "Max");
            Console.WriteLine(new String('-',40));
            List<string> ParamNames = new List<string>();
            ParamNames = objMeasure.measurement.SelectMany(pn => pn.param.Select(n => n.name)).GroupBy(name => name).Select(grp => grp.FirstOrDefault()).ToList();
            foreach (string paramName in ParamNames)
            {
                List<decimal> AllValuesforParam = objMeasure.measurement.SelectMany(prm => prm.param.Where(x => x.name == paramName)).Select(v => v.Value).ToList();
                outputmatrices.Add(new Outputmatrix
                {
                    ParamName = paramName,
                    Low = Math.Round(AllValuesforParam.Min(), 2),
                    Avg = Math.Round(AllValuesforParam.Average(), 2),
                    Max = Math.Round(AllValuesforParam.Max(), 2)
                });
            }
            foreach (Outputmatrix opm in outputmatrices)
            {
                Console.WriteLine(opm.ParamName.PadRight(15, ' ') + opm.Low.ToString().PadRight(10, ' ') + opm.Avg.ToString().PadRight(10, ' ') + opm.Max);
            }
            Console.WriteLine(new String('x', 40));
        }
    }

    public class Outputmatrix
    {
        public string ParamName { get; set; }
        public decimal Low { get; set; }
        public decimal Avg { get; set; }
        public decimal Max { get; set; }
    }

    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class samples
    {

        private samplesMeasurement[] measurementField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("measurement")]
        public samplesMeasurement[] measurement
        {
            get
            {
                return this.measurementField;
            }
            set
            {
                this.measurementField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class samplesMeasurement
    {

        private samplesMeasurementParam[] paramField;

        private System.DateTime dateField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("param")]
        public samplesMeasurementParam[] param
        {
            get
            {
                return this.paramField;
            }
            set
            {
                this.paramField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public System.DateTime date
        {
            get
            {
                return this.dateField;
            }
            set
            {
                this.dateField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class samplesMeasurementParam
    {

        private string nameField;

        private decimal valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public decimal Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }


}
