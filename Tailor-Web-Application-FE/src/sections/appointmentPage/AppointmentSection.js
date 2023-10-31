/* eslint-disable arrow-body-style */
import React, {useState} from 'react';
import { AdapterDayjs } from '@mui/x-date-pickers/AdapterDayjs';
import { LocalizationProvider } from '@mui/x-date-pickers/LocalizationProvider';
import { DatePicker } from '@mui/x-date-pickers/DatePicker';

import { Box, Typography, TextareaAutosize  } from '@mui/material';
import ContactUsPhoto from '../../assets/ContactUsImage.jpg';

const AppointmentSection = () => {
    const [nameValue, setNameValue] = useState('');
    const [emailValue, setEmailValue] = useState('');
    const [phoneValue, setPhoneValue] = useState('');
    const [dateValue, setDateValue] = useState('');
    const [messageValue, setMessageValue] = useState('');
  
    const handleClearFields = () => {
      setNameValue('');
      setEmailValue('');
      setPhoneValue('');
      setDateValue('');
      setMessageValue('Mesajul a fost transmis echipei noastre. Multumim !');
    };

    return (
        <Box sx = {{
            display: 'flex',
            flexDirection: 'column',
            px: '50px',
            height: '650px',
            mx: '20px',
            mb:'20px',
        }}> 
            <Box sx = {{
                display: 'flex',
                flexDirection: 'row',
                mt: '50px',
            }}>
                <Typography sx = {{
                    display: 'flex',
                    width: '50%',
                    fontSize: '40px',
                }}> 
                    Programeaza-te acum !
                </Typography>
                <Typography sx = {{
                    display: 'flex',
                    width: '50%',
                    fontSize: '20px',
                }}>  Nu ezita să ne contactezi pentru a programa o consultație personalizată sau pentru a plasa o comandă. Suntem disponibili să-ți oferim sfaturi și asistență pentru a-ți îndeplini dorințele legate de croitorie. Așteptăm cu nerăbdare să te ajutăm!</Typography>
            </Box>

            <Box sx = {{
                display: 'flex',
                flexDirection: 'row',
                Width: '100%',
                height: '450px',
                mt: '50px',
            }}>
                <Box sx = {{
                    display: 'flex',
                    justifyContent: 'center',
                    alignItems: 'center',
                    width: '70%',
                    flexDirection: 'column',
                }}>  

                <Box sx = {{
                    display:'flex',
                    justifyContent: 'center',
                    alignItems: 'center',
                    flexDirection: 'row',
                    }}>

                    <TextareaAutosize
                        aria-label="empty textarea"
                        placeholder="Numele tau ..."
                        style={{
                        width: '20rem',
                        height: '55px',
                        borderRadius: '5px',
                        padding: '10px',
                        resize: 'none',
                        margin: '1rem',
                        backgroundColor: '#FBF7F3',
                    }} value={nameValue}
                    onChange={(e) => setNameValue(e.target.value)}/>

                    <TextareaAutosize
                        aria-label="empty textarea"
                        placeholder="Emailul tau ..."
                        style={{
                        width: '20rem',
                        height: '55px',
                        borderRadius: '5px',
                        padding: '10px',
                        resize: 'none',
                        margin: '1rem',
                        backgroundColor: '#FBF7F3',
                    }}value={emailValue}
                    onChange={(e) => setEmailValue(e.target.value)}/>
                </Box>
                <Box sx = {{
                    display:'flex',
                    justifyContent: 'center',
                    alignItems: 'center',
                    flexDirection: 'row',
                    }}>

                    <TextareaAutosize
                        aria-label="empty textarea"
                        placeholder="Numar de telefon ..."
                        style={{
                        width: '20rem',
                        height: '55px',
                        borderRadius: '5px',
                        padding: '10px',
                        resize: 'none',
                        margin: '1rem',
                        backgroundColor: '#FBF7F3',
                    }} value={phoneValue}
                    onChange={(e) => setPhoneValue(e.target.value)}/>

                    <Box sx = {{
                        width: '20rem',
                        margin: '1rem',
                        }}>
                        <LocalizationProvider dateAdapter={AdapterDayjs}>
                            <DatePicker sx = {{
                                backgroundColor: '#FBF7F3',
                                width: '20rem',
                                '&:hover': {
                                    color: 'red',
                                  },
                                }}
                                style = {{ color: 'red'}}/>
                        </LocalizationProvider>
                    </Box>
                </Box>
                
                <TextareaAutosize
                        aria-label="empty textarea"
                        placeholder="Subiect "
                        style={{
                        width: '42rem',
                        height: '10rem',
                        borderRadius: '5px',
                        padding: '10px',
                        margin: '1rem',
                        resize: 'none',
                        backgroundColor: '#FBF7F3',
                    }} value={messageValue}
                    onChange={(e) => setMessageValue(e.target.value)}/>

                    <Box sx = {{ width: '42rem'}}>
                        <Box sx = {{
                            display: 'flex',
                            justifyContent: 'center',
                            alignItems: 'center',
                            height: '60px',
                            width: '16rem',
                            backgroundColor: '#DEB18A',
                            color: 'white',
                            borderRadius: '7px',
                            fontSize: '22px',
                            }} onClick={handleClearFields}>
                            Programeaza-ma
                        </Box>
                    </Box>
                </Box>

                <Box sx = {{
                    display: 'flex',
                    overflow: 'hidden',
                    width: '30%',
                    height: '100%',
                }}>
                    <img src = {ContactUsPhoto} alt = ""/>
                </Box>
            </Box>
            
            
        </Box>
    )
};

export default AppointmentSection;