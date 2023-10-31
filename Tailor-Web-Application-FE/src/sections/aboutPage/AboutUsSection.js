/* eslint-disable arrow-body-style */
import { Box, Typography } from '@mui/material';
import { FormattedMessage } from 'react-intl';

import AddIcCallIcon from '@mui/icons-material/AddIcCall';

import sewingMan from "../../assets/Croitor.jpg";
import shape1 from "../../assets/shape-1.png";

import  { OrangeSeparator } from '../../components';

const AboutUsSection = () => {
    return (
        <Box sx = {{
            display: 'flex',
            justifyContent: 'center',
            alignItems: 'center',
            flexDirection: 'row',
            width : '100%',
            height: '620px',
        }}> 
        
            <Box sx = {{
                display: 'flex',
                flexDirection: 'column',
                py: '5rem',
                px: '5rem',
                width: '50%',
                height: '100%',
            }}> 
                 <img src = {shape1} alt = "" width = "60px"/>
            <Typography sx = {{fontSize: '20px', mb: '10px'}}><FormattedMessage id="lbl.aboutus.about"/></Typography>

            <Typography sx = {{fontSize : "45px"}}><FormattedMessage id="lbl.titleAbout.about.aboutSection"/></Typography>

            <Typography sx = {{fontSize : "20px", my: '20px', mb: '50px'}}>Un serviciu de croitorie personalizată care transformă visurile tale în realitate. Experți în arta tăierii și cusutului, suntem dedicați să creăm haine unice, adaptate perfect nevoilor și preferințelor tale.</Typography>

                <Box sx = {{
                    display: 'flex',
                    alignItems: 'center',
                    flexDirection: 'row',
                    mt: '20px'
                }}>
                <Box sx = {{
                            display: 'flex',
                            justifyContent: 'center',
                            alignItems: 'center',
                            borderRadius: "50%",
                            height: '5rem',
                            width: '5rem',
                            border: '4px solid #454456',
                            bottom: '10px',
                        }}>
                            <AddIcCallIcon sx={{ color: '#454456', fontSize: '50px', my: '5px', mx: '5px'}} />
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
                                fontSize: '23px',
                                color: 'black',
                                width: '20rem',
                                }}> 
                                <FormattedMessage id="lbl.needATailor.home.contactSection"/>
                            </Typography>

                            <Typography sx = {{
                                display: 'flex',
                                textAlign :'center',
                                fontSize: '25px',
                                fontWeight: 'bold',
                                color: 'black',
                                }}>
                                + 1- (123) 456-7890
                            </Typography>
                </Box>
            </Box>

            </Box>
            <OrangeSeparator h = '100%' w = '10px'/>
            <Box sx = {{
                display: 'flex',
                justifyContent: 'center',
                alignItems: 'center',
                flexDirection: 'row',
                width: '50%',
                height: '100%',
            }}> 

                <Box sx = {{
                    width: '40rem',
                }}>                
                    <img src = {sewingMan} alt = ''/>
                </Box>

            </Box>
         </Box>
    )
};

export default AboutUsSection;