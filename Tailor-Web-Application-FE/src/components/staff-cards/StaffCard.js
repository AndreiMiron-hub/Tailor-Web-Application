/* eslint-disable arrow-body-style */
import { Box, Typography } from '@mui/material';

import FacebookIcon from '@mui/icons-material/Facebook';
import TwitterIcon from '@mui/icons-material/Twitter';
import InstagramIcon from '@mui/icons-material/Instagram';
import PinterestIcon from '@mui/icons-material/Pinterest';


const StaffCard= ({ name, staffRole, img,  facebook, twitter, instagram, pinterest }) => {
    return (
        <Box sx={{
            display: 'flex',
            justifyContent: 'center',
            alignItems: 'center',
            flexDirection: 'column',
            backgroundColor: 'white',
            width: '350px',
            height: '480px',
            border: '2px dotted #DEB18A',
            mx: '2rem',
            mt: '20px',
            position: 'relative', 
            overflow:'hidden',
            }}>
            <Box
                sx={{
                    display: 'flex',
                    justifyContent: 'center',
                    alignItems: 'center',
                    flexDirection: 'column',
                    backgroundColor: 'white',
                    width: '350px',
                    height: '420px',
                    mx: '2rem',
                    position: 'absolute',
                    top: '0',
                    zIndex: 1, 
                    overflow:'hidden',
                }}>
                <img src={img} alt="" style={{ position: 'relative', zIndex: 2, objectFit: 'cover', height: '100%' }} />

                
            </Box>
            
            <Box
                className="staffInfo"
                sx={{
                display: 'flex',
                justifyContent: 'center',
                alignItems: 'center',
                flexDirection: 'column',
                backgroundColor: 'white',
                width: '300px',
                height: '110px',
                position: 'absolute', 
                bottom: '0', 
                zIndex: 3, 
                }}>
                <Typography>{name}</Typography>
                <Typography>{staffRole}</Typography>

                <Box sx = {{
                    display: 'flex',
                    flexDirection: 'row',
                    justifyContent: 'center',
                    alignItems: 'center',
                    }}>
                    
                    <Box sx = {{
                        display: 'flex',
                        justifyContent: 'center',
                        alignItems: 'center',
                        backgroundColor: '#DEB18A',
                        width: '30px',
                        height: '30px',
                        borderRadius: '7px',
                        mr: '20px',
                    }}>
                        <FacebookIcon sx={{ display: 'flex', color: '#3A3949', fontSize: '25px' }} />
                    </Box>

                    <Box sx = {{
                        display: 'flex',
                        justifyContent: 'center',
                        alignItems: 'center',
                        backgroundColor: '#DEB18A',
                        width: '30px',
                        height: '30px',
                        borderRadius: '7px',
                        mr: '20px',
                    }}>
                        <TwitterIcon sx={{display: 'flex',  color: '#3A3949', fontSize: '25px' }} />
                    </Box>

                    <Box sx = {{
                        display: 'flex',
                        justifyContent: 'center',
                        alignItems: 'center',
                        backgroundColor: '#DEB18A',
                        width: '30px',
                        height: '30px',
                        borderRadius: '7px',
                        mr: '20px',
                    }}>
                        <PinterestIcon sx={{display: 'flex',  color: '#3A3949', fontSize: '25px' }} />
                    </Box>

                    <Box sx = {{
                        display: 'flex',
                        justifyContent: 'center',
                        alignItems: 'center',
                        backgroundColor: '#DEB18A',
                        width: '30px',
                        height: '30px',
                        borderRadius: '7px',
                    }}>
                        <InstagramIcon sx={{display: 'flex',  color: '#3A3949', fontSize: '25px' }} />
                    </Box>
                </Box>
            </Box>
        </Box>
    );
};

export default StaffCard;