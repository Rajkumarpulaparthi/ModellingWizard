﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aml.Editor.Plugin
{
    // this class initialize the parameters exclusively for the "Device Identofication", "DataGridViews in "Generic Data Tab" AND "Field Attachables Tab""
    public class MWDevice: MWData.MWObject
    {
        public string  semanticsystem { get; set; }
        public string semanticSystemVersion { get; set; }
        public string semanticSystemClassificationSystem { get; set; }
        public string deviceType { get; set; }
        public int? vendorID { get; set; }
        public string vendorName { get; set; }
        public string vendorHomepage { get; set; }
        public int? deviceID { get; set; }
        public string deviceName { get; set; }
        public string productRange { get; set; }
        public string productNumber { get; set; }
        // Can contain letters:
        public string orderNumber { get; set; }
        public string productText { get; set; }
        public string ipProtection { get; set; }
        public string harwareRelease { get; set; }
        public string softwareRelease { get; set; }
        public double minTemperature { get; set; }
        public double maxTemperature { get; set; }
        public string vendorLogo { get; set; }
        public string deviceIcon { get; set; }
        public string devicePicture { get; set; }
        public string productFamily { get; set; }
        public string productGroup { get; set; }
        public string decOfConfDocument { get; set; }
        public string shortGuideDocument { get; set; }
        public string billOfMaterialsDocument { get; set; }
        public List<DataGridParameters> dataGridParametersLists { get; set; }
       


        //Properties for Electrical Interface

        public List<ElectricalParameters> ElectricalInterfaces { get; set; }
        public List<List<ElectricalParameters>> ElectricalInterfaceInstances { get; set; }

        //List of property for parameters in Attachables Data Grid View
        public List<AttachablesDataGridViewParameters> dataGridAttachablesParametrsList { get; set; }
        public List<AttachablesDataGridViewParameters> listWithURIConvertedToString { get; set; }

        //List of parameters from Electrical Interface Datagrid View in "Inter" tab
        public List<ElectricalInterfaceParameters> listofElectricalInterfaceParameters { get; set; }

        // In this Dictionary Every list generated from the Electrical Interface is Added and can be retrived by the key KEY = "InterfaceClass+Externalinterface" strings
        public Dictionary<string, List<ElectricalInterfaceParameters>> DictofElectricalInterfaceParameters { get; set; }

    }
    // This class helps to carry parameters in "identification data table to AutomationML"

    public class DataGridParameters
    {
        public string RefSemantics { get; set; }
        public string Attributes { get; set; }
        public string Values { get; set; }
        

        public DataGridParameters() { }

        public DataGridParameters(string refSemantic, string attributes, string value)
        {
            this.RefSemantics  = refSemantic;
            this.Attributes = attributes;
           this.Values = value;

        }
        public override string ToString()
        {
            return "DataGridParameters(" + RefSemantics + "=" + Attributes + "=" + Values + ")";
        }

    }
  
   
   
   


    /// <summary>
    /// /The following classes are parameter holders for Electrical Interfaces
    /// </summary>
    public class ElectricalParameters
    {
        public string Connector { get; set; }
        public string ConnectorCode { get; set; }
        public string ConnectorType { get; set; }
        public string Pins { get; set; }

        public List<ElectricalParametersInElectricalDataDataGridView> listofElectricalDataDataGridViewParameters { get; set; }
        public List<PinParametersInPinInfoDataGridView> listOfPinInfoDataGridViewParameters { get; set; }
        //public string ReferenceID { get; set; }
        //public string Attributes { get; set; }
        //public string Values { get; set; }
        //public string Units { get; set; }


        public ElectricalParameters() 
        {
           
        }
        
        public ElectricalParameters(string connector, string connectorCode, string connectorType,string pins,string lis)
            
        {
            this.Connector = connector;
            this.ConnectorCode = connectorCode;
            this.ConnectorType = connectorType;
            this.Pins = pins;
            
        }
        //public ElectricalParameters(string referenceID, string attribute, string values, string units, string pins)
        //{ 
        //    this.ReferenceID = referenceID;
        //    this.Attributes = attribute;
        //    this.Values = values;
        //    this.Units = units;
        //    this.Pins = pins;
        //}
       
        public override string ToString()
        {
          
            return "ElectricalParameters(" + Connector + "=" + ConnectorCode + "=" + ConnectorType + "="+Pins+")";
        }
       
    }
    //This Class is responsible to hold the parameters in "ElectricalDataDataGrid View"

    public class ElectricalParametersInElectricalDataDataGridView
    {
       
        public string ReferenceID { get; set; }
        public string Attributes { get; set; }
        public string Values { get; set; }
        public string Units { get; set; }

        public ElectricalParametersInElectricalDataDataGridView()
        {

        }
        public ElectricalParametersInElectricalDataDataGridView(string referenceID, string attribute, string values, string units)
        {
            this.ReferenceID = referenceID;
            this.Attributes = attribute;
            this.Values = values;
            this.Units = units;
            
        }
        public override string ToString()
        {
            return "ElectricalParametersInElectricalDataDataGridView("+ ReferenceID + "=" + Attributes + "=" + Values + "=" + Units + ")";
        }

        
    }

    public class PinParametersInPinInfoDataGridView
    {
        public string PinNumber { get; set; }
        public string ReferenceID { get; set; }
        public string Attributes { get; set; }
        public string Values { get; set; }
        public string Units { get; set; }

        public PinParametersInPinInfoDataGridView()
        {

        }
        public PinParametersInPinInfoDataGridView(string pinNumber,string referenceID, string attribute, string values, string units)
        {
            this.PinNumber = pinNumber;
            this.ReferenceID = referenceID;
            this.Attributes = attribute;
            this.Values = values;
            this.Units = units;

        }
        public override string ToString()
        {
            return "PinParametersInPinInfoDataGridView(" +PinNumber+"="+ ReferenceID + "=" + Attributes + "=" + Values + "=" + Units + ")";
        }


    }



    // this class is responsible to load every parameter in "attachablesInfoDataGridView" into a list.
    public class AttachablesDataGridViewParameters
    {

        public string ElementName { get; set; }
        public string FilePath { get; set; }
       
        

        public AttachablesDataGridViewParameters()
        {

        }
        public AttachablesDataGridViewParameters(string elementName, string filePath)
        {
            this.ElementName = elementName;
            this.FilePath = filePath;
           
            

        }
        public override string ToString()
        {
            return "AttachablesDataGridViewParameters(" + ElementName + "=" + FilePath +  ")";
        }



        
    }
    public class ElectricalInterfaceParameters
    {
        public string AttributeName { get; set; }
        public string Values { get; set; }
        public string Default { get; set; }
        public string Units { get; set; }
        public string DataType { get; set; }
        public string Semantic { get; set; }
        public string Reference { get; set; }
        public string Description { get; set; }
        public string CopyRight { get; set; }
        public string AttributePath { get; set; }
        //public List<ClassOfListsFromReferencefile> listofparameters { get; set; }

        public ElectricalInterfaceParameters()
        {
            //listofparameters = new List<ClassOfListsFromReferencefile>();
        }

        public ElectricalInterfaceParameters(string name, string value,
            string _default, string unit,
            string reference, string description, string copyRight, string semantic, string attributePath)
            : this()
        {
            this.AttributeName = name;
            this.Values = value;
            this.Default = _default;
            this.Units = unit;
            this.Reference = reference;
            this.Description = description;
            this.CopyRight = copyRight;
            this.Semantic = semantic;
            this.AttributePath = attributePath;
        }

        public override string ToString()
        {
            return "ClassOfListsFromReferencefile(" + AttributeName + "=" + Values + "=" + Default + "=" + Units + "=" + Reference + "="
                + Description + "=" + CopyRight + "=" + Semantic + "=" + AttributePath + ")";
        }
    }
}




