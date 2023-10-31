import React from 'react';
import { NavLink as RouterLink } from 'react-router-dom';
import PropTypes from 'prop-types';
import { FormattedMessage } from 'react-intl';
// @mui
import { Grid, Typography,  Box,  List, ListItemText } from '@mui/material';
import FacebookIcon from '@mui/icons-material/Facebook';
import TwitterIcon from '@mui/icons-material/Twitter';
import InstagramIcon from '@mui/icons-material/Instagram';
import PinterestIcon from '@mui/icons-material/Pinterest';
//

export default function Footer({social = [], services = [], legal =[]}) {
    return (
     <Box sx = {{
        
        width:'100%',
        height: '500px',
        overflow: 'visible',
        backgroundColor:"#454456",
        position: 'relative',
        }}>
            <Box sx = {{
                display: 'flex',
                displayFlex : 'row',
                justifyContent: 'center',
                alignItems: 'center',
                pt: '40px',
            }}>
            <Box className = "left footer" sx = {{
                    display:'flex',
                    flexDirection: 'column',
                    justifyContent: 'center',
                    alignItems: 'left',
                    height: '200px',
                    maxWidth: '700px',
                    width: '100%',
                }}>
                <Box sx = {{
                    display: 'flex',
                    alignItems: 'left',
                    justifyContent: 'center',
                    flexDirection: 'column',
                    mb: '20px',
                }}>
                    <Typography sx = {{
                        display : 'flex', 
                        textAlign: 'center',
                        color : 'white',
                        fontSize: '25px',
                        }}> <FormattedMessage id="lbl.callAnyTime.footer"/></Typography>

                    <Typography sx = {{
                        display : 'flex', 
                        textAlign: 'center',
                        color : '#DEB18A',
                        fontSize: '35px',
                        }}> + 1- (246) 333-0089 </Typography>
                </Box>
                <Box sx = {{
                    display: 'flex',
                    justifyContent: 'left',
                    alignItems: 'center',
                    flexDirection: 'row',
                }}>
                    <Box sx = {{
                        display: 'flex',
                        justifyContent: 'center',
                        alignItems: 'center',
                        backgroundColor: '#3A3949',
                        width: '50px',
                        height: '50px',
                        borderRadius: '7px',
                        mr: '20px',
                    }}>
                        <FacebookIcon sx={{ color: '#AAA9B5', fontSize: '30px' }} />
                    </Box>

                    <Box sx = {{
                        display: 'flex',
                        justifyContent: 'center',
                        alignItems: 'center',
                        backgroundColor: '#3A3949',
                        width: '50px',
                        height: '50px',
                        borderRadius: '7px',
                        mr: '20px',
                    }}>
                        <TwitterIcon sx={{ color: '#AAA9B5', fontSize: '30px' }} />
                    </Box>

                    <Box sx = {{
                        display: 'flex',
                        justifyContent: 'center',
                        alignItems: 'center',
                        backgroundColor: '#3A3949',
                        width: '50px',
                        height: '50px',
                        borderRadius: '7px',
                        mr: '20px',
                    }}>
                        <PinterestIcon sx={{ color: '#AAA9B5', fontSize: '30px' }} />
                    </Box>

                    <Box sx = {{
                        display: 'flex',
                        justifyContent: 'center',
                        alignItems: 'center',
                        backgroundColor: '#3A3949',
                        width: '50px',
                        height: '50px',
                        borderRadius: '7px',
                        mr: '20px',
                    }}>
                        <InstagramIcon sx={{ color: '#AAA9B5', fontSize: '30px' }} />
                    </Box>
                </Box>
            </Box>

<Box className = "rightFooter" sx = {{
    display: 'flex',
    flexDirection: 'column',
    }}>
    <Box className = "FooterButtons" sx = {{
            display: 'flex',
            flexDirection: 'row',
            margin: '30px',
            width: '100%',
        }}>
        <Box className = "FooterLinksSection" 
            sx = {{
            display: 'flex',
            justifyContent: 'left',
            alignItems: 'left',
            flexDirection: 'column',
            width: '40%',
            pl: '40px',
            }}>
            <Typography sx = {{color : 'white', fontWeight: 'bold', fontSize: '20px', mb: '10px'}}> <FormattedMessage id="lbl.services.header"/> </Typography>
            
            <Typography component={RouterLink}
                        to={'/services'}
                        sx= {{color : '#AAA9B5'}}> 
                        Servicii 
                        </Typography>

            <Typography component={RouterLink}
                        to={'/appointment'}
                        sx= {{color : '#AAA9B5'}}> 
                        Programare
                        </Typography>

            <Typography component={RouterLink}
                        to={'/products'}
                        sx= {{color : '#AAA9B5'}}> 
                        Produse 
                        </Typography>
            
        </Box>

        <Box className = "FooterLinksSection" 
            sx = {{
            display: 'flex',
            justifyContent: 'left',
            alignItems: 'left',
            flexDirection: 'column',
            width: '40%',
            pl: '40px',
            }}>
            <Typography sx = {{color : 'white', fontWeight: 'bold', fontSize: '20px', mb: '10px'}}> <FormattedMessage id="lbl.links.footer"/> </Typography>
            
            <Typography component={RouterLink}
                        to={'/about'}
                        sx= {{color : '#AAA9B5'}}> 
                        <FormattedMessage id="lbl.about.header"/>
                        </Typography>

            <Typography component={RouterLink}
                        to={'/team'}
                        sx= {{color : '#AAA9B5'}}> 
                        <FormattedMessage id="lbl.meetTheTeam.footer"/>
                        </Typography>

            <Typography component={RouterLink}
                        to={'/galery'}
                        sx= {{color : '#AAA9B5'}}> 
                        <FormattedMessage id="lbl.galery.footer"/>
                        </Typography>

            <Typography component={RouterLink}
                        to={'/contact'}
                        sx= {{color : '#AAA9B5'}}> 
                        <FormattedMessage id="lbl.contactus.footer"/>
                        </Typography>

            <Typography component={RouterLink}
                        to={'/login'}
                        sx= {{color : '#AAA9B5'}}> 
                        <FormattedMessage id="lbl.footer.login"/>
                        </Typography>
        </Box>

        <Box className = "FooterLegalSection" 
            sx = {{
            display: 'flex',
            justifyContent: 'left',
            alignItems: 'left',
            flexDirection: 'column',
            width: '40%',
            pl: '40px',
            }}>
            <Typography sx = {{color : 'white', fontWeight: 'bold', fontSize: '20px', mb: '10px'}}> <FormattedMessage id="lbl.legal.footer"/> </Typography>
            
            <Typography component={RouterLink}
                        to={'/help'}
                        sx= {{color : '#AAA9B5'}}> 
                        <FormattedMessage id="lbl.help.footer"/>  
                        </Typography>

            <Typography component={RouterLink}
                        to={'/team'}
                        sx= {{color : '#AAA9B5'}}> 
                        <FormattedMessage id="lbl.tac.footer"/>  
                        </Typography>

            <Typography component={RouterLink}
                        to={'/galery'}
                        sx= {{color : '#AAA9B5'}}> 
                        <FormattedMessage id="lbl.pc.footer"/>  
                        </Typography>
        </Box>
    </Box>

    <Box className ="rightFooterInfo" sx = {{
        display: "flex",
        justifyContent: 'center',
        flexDirection: 'row',
        mt: '20px',
    }}>
            <Box sx = {{
                display: 'flex', 
                justifyContent: 'center',
                alignItems: 'center',
                flexDirection: 'column',
                width: '50%',
                }}>
                <Typography sx={{ 
                    color: '#AAA9B5',
                    fontSize: '20px',
                    }}>
                    <FormattedMessage id="lbl.visitUs.footer"/></Typography>

                <Typography sx={{ 
                    color: 'white',
                    fontSize: '20px',
                    }}>
                    Strada mea numarul 2, Botosani
                </Typography>
            </Box>

        <Box sx = {{
            display: 'flex', 
            justifyContent: 'center',
            alignItems: 'center',
            flexDirection: 'column',
            width: '50%'
            }}>
            <Typography sx={{ 
                color: '#AAA9B5',
                fontSize: '20px',
                }}>
                <FormattedMessage id="lbl.contactus.footer"/>
            </Typography>

            <Typography sx={{ 
                color: 'white',
                fontSize: '20px',
            }}>
                info@companie.com
            </Typography>
        </Box>
    </Box>
</Box>
    </Box>

            <Box className = "Base Footer" sx = {{
                display: 'flex',
                overflow: 'visible',
                justifyContent: 'center',
                alignItems: 'center',
                height: '80px',
                width: '100%',
                backgroundColor: '#3A3949',
                marginTop: 'auto',
                position: 'absolute',
                bottom: 0,
                }}>
            <Typography sx={{ 
                color: '#AAA9B5',
                fontSize: '15px',
                }}>
                    &#169; 2023 My Company. All rights reserved.
            </Typography>
            </Box>
    </Box>
    );
  }