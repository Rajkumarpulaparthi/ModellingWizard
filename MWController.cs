﻿using System;
using System.Collections.Generic;

namespace Aml.Editor.Plugin
{
    /// <summary>
    /// This class passes the inputs of the GUIs to <see cref="MWData"/> where needed and it is in controll of what is displayed at the screen
    /// </summary>
    public class MWController
    {
        // the (initialised) GUIs
        private CreateDevice createDeviceForm;
      
      
        private DeviceDescription deviceDescriptionForm;
        

        // the interface class to the AML Editor
        private ModellingWizard modellingWizard;

        // the MWData instance of the the plugin which handles all the AMLX stuff
        private MWData mWData;

        // the list of the currently loaded amlx devices / interfaces
        // these will be displayed on the start GUI
        private List<MWData.MWObject> devices = new List<MWData.MWObject>();

        /// <summary>
        /// Init the controller and reload all amlx devices
        /// </summary>
        /// <param name="modellingWizard"></param>
        public MWController(ModellingWizard modellingWizard)
        {
            this.modellingWizard = modellingWizard;
            mWData = new MWData(this);
            ReloadObjects();
        }

        /// <summary>
        /// Create the new CreateDevice GUI or return the previously created GUI
        /// </summary>
        /// <returns>the CreateDevice GUI for this session</returns>
        public CreateDevice GetCreateDeviceForm()
        {
            if (createDeviceForm == null)
            {
                createDeviceForm = new CreateDevice(this);
            }

            return createDeviceForm;
        }
        /// <summary>
        /// creáte the new DeviceDescription GUI or return the previously created GUI
        /// </summary>
        public DeviceDescription GetDeviceDescriptionForm()
        {
            if (deviceDescriptionForm == null)
            {
                deviceDescriptionForm = new DeviceDescription(this);
            }
            return deviceDescriptionForm;
        }
        
      
        


       
      

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newDevice"></param>
        /// <param name="isEdit"></param>
        /// <returns></returns>
        public String CreateDeviceOnClick(MWDevice newDevice, bool isEdit)
        {
            string result = "";
            // Check if device Name is set
            if (newDevice.deviceName.Equals(""))
            {
                return "Error no device name set!";
            }

            // Check if vendor name is set
            if (newDevice.vendorName.Equals(""))
            {
                return "Error no vendor name set!";
            }
            if (newDevice.deviceName != null && newDevice.vendorName != null)
            {
                // create the device
                 result = mWData.CreateDevice(newDevice, isEdit);
            }

            // update the device list
            if (isEdit)
            {
                ReloadObjects();
            }
            else
            {
                devices.Add(newDevice);
               
            }

          
            return result;

        }

        /// <summary>
        /// Show the correct GUI for the selected device
        /// </summary>
        /// <param name="selectedIndex">The index of the selected item in the dropdown</param>
        internal void showDevice(int selectedIndex)
        {
            if (devices.Count >= 1)
            {
                MWData.MWObject mWObject = devices[selectedIndex];
                // Display the corect GUI for the object type
                if (mWObject is MWDevice)
                {
                    GetCreateDeviceForm().prefill((MWDevice)mWObject);
                    ChangeGui(MWGUIType.CreateDevice);
                }
               
                
            }
        }

        /// <summary>
        /// Load the AMLX file and display the loaded device
        /// </summary>
        /// <param name="fileName">the full path to an .amlx file</param>
        internal void showDevice(string fileName)
        {
            MWData.MWObject mWObject = mWData.loadObject(fileName);
            if (mWObject == null)
            {
                System.Windows.Forms.MessageBox.Show("The loaded device does not match the required format.\nThe ModellingWizard can not display this object");
                return;
            }
            devices.Add(mWObject);
           

            // show the most recently added device
            showDevice(devices.Count - 1);
        }

        /// <summary>
        /// Reload all .amlx files in ./modellingwizard/ and update the dropdown.
        /// </summary>
        internal void ReloadObjects()
        {
            devices = mWData.LoadMWObjects();
           
        }

        /// <summary>
        /// Switch the displayed 
        /// </summary>
        /// <param name="targetGUI">the GUI Type to display</param>
        public void ChangeGui(MWGUIType targetGUI)
        {
            switch (targetGUI)
            {
                case MWGUIType.CreateDevice:
                    modellingWizard.changeGUI(GetCreateDeviceForm());
                    break;
               
               
                case MWGUIType.DeviceDescription:
                    modellingWizard.changeGUI(GetDeviceDescriptionForm());
                    break;

            }
        }

        /// <summary>
        /// Enum to represent the GUI
        /// </summary>
        public enum MWGUIType { CreateDevice, CreateInterface, Start, DeviceDescription }

        /// <summary>
        /// Call the Converter with the given file
        /// </summary>
        /// <param name="filename">the full path to the file</param>
        /// <param name="filetype">whether the file is an IODD or an GSD file</param>
        /// <returns></returns>
        public string importFile(string filename, MWData.MWFileType filetype)
        {

            // call the correct import function for the file type
            string result = null;
            switch (filetype)
            {
                case MWData.MWFileType.IODD:
                    result = mWData.ImportIODD2AML(filename);
                    break;
                case MWData.MWFileType.GSD:
                    result = mWData.ImportGSD2AML(filename);
                    break;
                default:
                    result = "Invalid Filetype";
                    break;
            }
            ReloadObjects();
            return result;
        }
    }
}
