/* eslint-disable arrow-body-style */
import { Box, Typography } from '@mui/material';
import { FormattedMessage } from 'react-intl';

const InformationSection = () => {
    return (
        <Box sx = {{
            display: 'flex',
            flexDirection: 'row',
            px: '50px',
            height: '150px'
        }}>
            <Box sx = {{
                    display: 'flex',
                    justifyContent: 'center',
                    alignItems: 'left',
                    flexDirection: 'column',
                    width: '33%',
                }}>
                <Typography sx = {{ fontSize: '25px', color: '#DEB18A'}}> <FormattedMessage id="lbl.sendEmail.contact.contactSection"/> </Typography>
                <Typography sx = {{ fontSize: '25px', color: 'black'}}> neehelp@company.com </Typography>

            </Box>

            <Box sx = {{
                    display: 'flex',
                    justifyContent: 'center',
                    alignItems: 'left',
                    flexDirection: 'column',
                    width: '33%',
                }}>
                <Typography sx = {{ fontSize: '25px', color: '#DEB18A'}}> <FormattedMessage id="lbl.call247.contact.contactSection"/> </Typography>
                <Typography sx = {{ fontSize: '25px', color: 'black'}}> + 1- (246) 333-0089 </Typography>
            </Box>

            <Box sx = {{
                    display: 'flex',
                    justifyContent: 'center',
                    alignItems: 'left',
                    flexDirection: 'column',
                    width: '33%',
                }}>
                <Typography sx = {{ fontSize: '25px', color: '#DEB18A'}}> <FormattedMessage id="lbl.visitAnytime.contact.contactSection"/> </Typography>
                <Typography sx = {{ fontSize: '25px', color: 'black'}}> Strada mea numarul 2, Botosani </Typography>
            </Box>
        
        </Box>
    )
};

export default InformationSection;