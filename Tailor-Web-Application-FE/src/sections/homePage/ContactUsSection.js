/* eslint-disable arrow-body-style */
import { NavLink as RouterLink } from 'react-router-dom';
import { FormattedMessage } from 'react-intl';
import { Box, Typography } from '@mui/material';

import AddIcCallIcon from '@mui/icons-material/AddIcCall';

const ContactUsSection = () => {
    return (
        <Box sx = {{
            display: 'flex',
            justifyContent: 'center',
            alignContent: 'center',
            height: '300px',
            width: '100%',
            bgcolor: '#DEB18A',
        }}>
            <Box sx = {{
                display: 'flex',
                justifyContent: 'center',
                alignItems: 'center',
                width: '33%',
                flexDirection: 'row',
            }}>

                <Box sx = {{
                        display: 'flex',
                        justifyContent: 'center',
                        alignItems: 'center',
                        flexDirection: 'column',
                    }}>
                        <Box sx = {{
                            display: 'flex',
                            justifyContent: 'center',
                            alignItems: 'center',
                            borderRadius: "50%",
                            border: '4px solid #454456',
                        }}>
                            <AddIcCallIcon sx={{ color: '#454456', fontSize: '50px', my: '5px', mx: '5px'}} />
                        </Box>
                </Box>

                <Box sx = {{
                        display: 'flex',
                        justifyContent: 'center',
                        alignItems: 'center',
                        flexDirection: 'column',
                        width: '20rem',
                    }}>

                            <Typography sx = {{
                                display: 'flex',
                                textAlign :'center',
                                fontSize: '25px',
                                color: 'white',
                                width: '20rem',
                                }}> 
                                <FormattedMessage id="lbl.needATailor.home.contactSection"/>
                            </Typography>

                            <Typography sx = {{
                                display: 'flex',
                                textAlign :'center',
                                fontSize: '30px',
                                color: 'white',
                                }}>
                                + 1- (123) 456-7890
                            </Typography>
                </Box>
            </Box>

            <Box sx = {{
                display: 'flex',
                justifyContent: 'center',
                alignItems: 'center',
                width: '33%',
                flexDirection: 'row',
            }}>
                <Typography sx = {{
                        fontSize: '25px',
                        color: 'white',
                    }}>
                    Experimentează calitatea croitoriei noastre excepționale. Contactează-ne acum!
                </Typography>
            </Box>

            <Box sx = {{
                display: 'flex',
                justifyContent: 'center',
                alignItems: 'center',
                width: '33%',
                flexDirection: 'row',
            }}>
                <Box component={RouterLink}
                        to={'/contact'}
                    sx = {{
                    display: 'flex',
                    justifyContent: 'center',
                    alignItems: 'center',
                    width: '250px',
                    height: '75px',
                    border: '4px solid white',
                    borderRadius: '7px',
                    textDecoration: 'none',
                }}>
                    <Typography
                         sx = {{
                            fontSize: '20px',
                            color: 'white',
                            fontWeight: 'bold',
                            }}>
                        <FormattedMessage id="lbl.contactus.contactSection"/>
                    </Typography>
                </Box>
            </Box>
        </Box>
    );
};

export default ContactUsSection;