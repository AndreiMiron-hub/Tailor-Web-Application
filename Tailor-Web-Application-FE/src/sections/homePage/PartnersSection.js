/* eslint-disable arrow-body-style */
import { Box, Typography } from '@mui/material';

import image from "../../assets/Croitor.jpg";

const PartnersSection= ({ name, staffRole, img,  facebook, twitter, instagram, pinterest }) => {
    return (
        <Box sx={{
            display: 'flex',
            justifyContent: 'center',
            alignItems: 'center',
            flexDirection: 'row',
            height: '150px',
            width: '100%',
            backgroundColor: 'white',
            }}/>
    );

};

export default PartnersSection;