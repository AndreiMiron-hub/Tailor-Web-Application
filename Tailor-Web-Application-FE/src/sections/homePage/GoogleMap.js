/* eslint-disable arrow-body-style */
import React, { useEffect } from 'react';

import { Box } from '@mui/material';

const GoogleMap = () => {

    useEffect(() => {
        const loadMap = () => {
          const googleMapScript = document.createElement('script');
          googleMapScript.src = `https://maps.googleapis.com/maps/api/js?key=AIzaSyD1guUc30jG1a5OKll28c2TRoe9kr5vhU8&libraries=places`;
          googleMapScript.onload = initMap;
          document.head.appendChild(googleMapScript);
        };
        const initMap = () => {
          const map = new window.google.maps.Map(document.getElementById('google-map'), {
            center: { lat: 47.64125278927602, lng: 26.243957469396136 },
            zoom: 15, 
          });
    
        };

        loadMap();
      }, []);

    return (
        <Box
        id ="google-map" 
        sx = {{
            display: 'flex',
            justifyContent: 'center',
            alignItems:'center',
            height: '500px',
            width: '100%',
            backgroundColor: 'lightblue'

        }}> 
        GoogleMap 
        </Box>
    );
};

export default GoogleMap;