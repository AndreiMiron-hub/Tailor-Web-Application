/* eslint-disable arrow-body-style */
import React, { useState } from 'react';
import { Box, Typography, TextareaAutosize  } from '@mui/material';
import { FormattedMessage, useIntl } from 'react-intl';

import ContactUsPhoto from '../../assets/ContactUsImage.jpg'

const ContactUsFormSection = () => {
    const intl = useIntl();
    const [nameValue, setNameValue] = useState('');
    const [emailValue, setEmailValue] = useState('');
    const [phoneValue, setPhoneValue] = useState('');
    const [subjectValue, setSubjectValue] = useState('');
    const [messageValue, setMessageValue] = useState('');
  
    const handleClearFields = () => {
      setNameValue('');
      setEmailValue('');
      setPhoneValue('');
      setSubjectValue('');
      setMessageValue('Mesajul a fost transmis echipei noastre. Multumim !');
    };

    return (
        <Box sx = {{
            display: 'flex',
            flexDirection: 'column',
            px: '50px',
            height: '650px',
            mx: '20px',
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
                <FormattedMessage id="lbl.sendEmailLong.contact.contactSection"/>
            </Typography>
            <Typography sx = {{
                display: 'flex',
                width: '50%',
                fontSize: '20px',
            }}>  Nu ezita să ne contactezi pentru orice întrebări, nelămuriri sau detalii despre produsele, serviciile sau ofertele noastre. Suntem aici să te ajutăm și să-ți oferim informațiile necesare.</Typography>
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
                    placeholder= {intl.formatMessage({ id: 'lbl.nume.contact.sendFormSection'})}
                    style={{
                    width: '20rem',
                    padding: '10px',
                    resize: 'none',
                    margin: '1rem',
                    backgroundColor: '#FBF7F3',
                }}             value={nameValue}
                onChange={(e) => setNameValue(e.target.value)}/>

                <TextareaAutosize
                    aria-label="empty textarea"
                    placeholder= {intl.formatMessage({ id: 'lbl.email.contact.sendFormSection'})}
                    style={{
                    width: '20rem',
                    padding: '10px',
                    resize: 'none',
                    margin: '1rem',
                    backgroundColor: '#FBF7F3',

                }}                    
                value={emailValue}
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
                    placeholder={intl.formatMessage({ id: 'lbl.numarTel.contact.sendFormSection'})}
                    style={{
                    width: '20rem',
                    padding: '10px',
                    resize: 'none',
                    margin: '1rem',
                    backgroundColor: '#FBF7F3',
                }}             value={phoneValue}
                onChange={(e) => setPhoneValue(e.target.value)}/>

                <TextareaAutosize
                    aria-label="empty textarea"
                    placeholder= {intl.formatMessage({ id: "lbl.subiect.contact.sendFormSection"})}
                    style={{
                    width: '20rem',
                    padding: '10px',
                    resize: 'none',
                    margin: '1rem',
                    backgroundColor: '#FBF7F3',
                }}             value={subjectValue}
                onChange={(e) => setSubjectValue(e.target.value)}/>
            </Box>
            
            <TextareaAutosize
                    aria-label="empty textarea"
                    placeholder={intl.formatMessage({ id: "lbl.text.contact.sendFormSection"})}
                    style={{
                    width: '42rem',
                    height: '10rem',
                    padding: '10px',
                    margin: '1rem',
                    resize: 'none',
                    backgroundColor: '#FBF7F3',
                }}             value={messageValue}
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
                        }} 
                        onClick={handleClearFields}
                        >
                        Trimite mesajul
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

export default ContactUsFormSection;