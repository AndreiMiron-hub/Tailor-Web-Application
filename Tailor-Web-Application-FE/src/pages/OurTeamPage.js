import React from 'react';
import { Helmet } from 'react-helmet-async';
import { Box, Typography } from '@mui/material';

import headerImage from '../assets/OurTeamBanner.jpg';
import { StaffCard } from '../components';

export default function OurTeam() {
  return (
    <>
    <Helmet>
      <title> Our Team | Tailor Website </title>
    </Helmet>

    <Box sx={{ 
      display: 'flex',
      overflow: 'hidden',
      position: 'relative', 
      width: '100%', 
      height: '400px'
      }}>

      <img
        width='100%'
        height='100%'
        style={{ objectFit: 'cover' }}
          src={headerImage}
          alt="" 
        />
    </Box>   
      
    <Typography
      sx={{
        position: 'absolute',
        top: '25%',
        left: '40%',
        color: 'white',
        fontWeight: 'bold',
        textShadow: '2px 2px 4px rgba(0, 0, 0, 0.5)',
        fontSize: '50px',
        zIndex: 2,
      }}>
      Echipa noastra
    </Typography>

    <Box sx = {{
        display: 'flex',
        flexDirection: 'column',
        justifyContent: 'center',
        alignItems: 'center',
        width: '100%',
        height: '100%',
        my: '50px',
    }}>
        <Box sx = {{
            display:'flex',
            flexDirection:'row',
            justifyContent: 'center',
            alignItems: 'center',
            width: '100%',
        }}>
            <StaffCard/>
            <StaffCard/>
            <StaffCard/>
        </Box>
        
        <Box sx = {{
            display:'flex',
            flexDirection:'row',
            justifyContent: 'center',
            alignItems: 'center',
            width: '100%',
        }}>
            <StaffCard/>
            <StaffCard/>
            <StaffCard/>
        </Box>
    </Box>
    

    </>
  );
}