using System;
using System.Collections.Generic;
using System.Linq;

namespace HomeSeer.PluginSdk.Devices {

    public class DeviceFactory {

        private HsDevice _device;
        private List<HsDevice> _features;
        
        #region Create
        
        //Create
        public static DeviceFactory CreateDevice(string pluginId) {
            var df = new DeviceFactory();
            var device = new HsDevice
                         {
                             Relationship = ERelationship.Device,
                             Interface = pluginId
                         };
            df._device = device;

            return df;
        }
        
        #endregion
                
        //Add Features
        public DeviceFactory WithFeature(FeatureFactory feature) {

            if (feature?.Feature == null) {
                throw new ArgumentNullException(nameof(feature));
            }

            if (_features == null) {
                _features = new List<HsDevice>();
            }
            
            _features.Add(feature.Feature);

            return this;
        }
        
        #region Device Properties

        public DeviceFactory WithName(string name) {

            if (string.IsNullOrWhiteSpace(name)) {
                throw new ArgumentNullException(nameof(name));
            }

            _device.Name = name;

            return this;
        }
        
        public DeviceFactory WithExtraData(PlugExtraData extraData) {

            if (extraData == null) {
                throw new ArgumentNullException(nameof(extraData));
            }

            _device.PlugExtraData = extraData;

            return this;
        }
        
        public DeviceFactory WithMiscFlags(params EDeviceMiscFlag[] miscFlags) {

            if (miscFlags == null || miscFlags.Length == 0) {
                throw new ArgumentNullException(nameof(miscFlags));
            }

            foreach (var miscFlag in miscFlags.Distinct()) {
                _device.AddMiscFlag(miscFlag);
            }
            
            return this;
        }
        
        public DeviceFactory WithProductImage(string imagePath) {

            if (string.IsNullOrWhiteSpace(imagePath)) {
                throw new ArgumentNullException(nameof(imagePath));
            }

            _device.ProductImage = imagePath;

            return this;
        }
        
        #endregion

        public DeviceFactory AsType(EDeviceType deviceType, int deviceSubType) {

            _device.DeviceType = new DeviceTypeInfo()
                                 {
                                     ApiType = EApiType.Device,
                                     Type    = (int) deviceType,
                                     SubType = deviceSubType
                                 };

            return this;
        }

        internal NewDeviceData PrepareForHs() {
            return new NewDeviceData(_device, _features);
        }
    }

}