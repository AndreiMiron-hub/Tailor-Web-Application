/* eslint-disable arrow-body-style */
import { Box, Typography } from '@mui/material';
import { NavLink as RouterLink, Link, useNavigate } from 'react-router-dom';

import AccountCircleOutlinedIcon from '@mui/icons-material/AccountCircleOutlined';

const LargeBlogCard= ({ article, writter, onSelected }) => {

    const navigate = useNavigate();

    const handleClick = () => {
        onSelected(article);
        navigate(`/blog/${article.id}`);
      };

    return (
        <Box
            sx={{
                display: 'flex',
                justifyContent: 'center',
                alignItems: 'center',
                flexDirection: 'column',
                width: '90%',
                height: '880px',
                position: 'relative',
                pt: '30px',
                // overflow: 'auto',
                backgroundColor: "#454456",
                my: 2,
                borderRadius: '15px',
            }}
            > 
            <img src = {article.image} 
                    alt = ""              
                    width = "800px"
                    style={{ 
                        borderRadius: '20px 20px 0 0',
                        objectFit: 'cover',
                        overflow: 'hidden',
                        justifyContent: 'center',
                        alignItems: 'center',
                    }}/>
            <Box 
                sx = {{
                    display: 'flex',
                    justifyContent: 'left',
                    alignItems: 'center',
                    flexDirection: 'row',
                    width: '50rem',
                    height: '80px',
                    backgroundColor: "#DEB18A",
                }}> 

                <Typography 
                sx = {{
                    display: 'flex',
                    flexDirection: 'row',
                    justifyContent: 'center',
                    alignItems: 'center',
                    textAlign: 'center',
                    mx: '15px'}}>
                        <AccountCircleOutlinedIcon sx = {{
                            color: '#DEB18A', 
                            fontSize: '18px'
                            }}/>  

                        {article.publishDate.substring(0, 10)}
                </Typography>

                <Typography sx = {{
                    display: 'flex',
                    flexDirection: 'row',
                    justifyContent: 'center',
                    alignItems: 'center',
                    textAlign: 'center',
                    mx: '15px'}}>
                        <AccountCircleOutlinedIcon sx = {{
                            color: '#DEB18A', 
                            fontSize: '18px'
                            }}/>  

                        {writter}
                </Typography>

            </Box>

            <Box 
                onClick={handleClick} 
                sx = {{
                display: 'flex',
                flexDirection: 'column',
                width: '50rem',
                height: '200px',
                borderRadius: '0 0 20px 20px',
                backgroundColor: "#DEB18A",
                px: '2rem',
                '&:hover': {
                    textDecoration: 'underline',
                    cursor: 'pointer',
                  },
                }}> 
                <Typography sx = {{
                        display: 'flex',
                        textAlign: 'left',
                        fontSize: '30px',
                        fontWeight: 'bold',
                        textDecoration: 'none',
                        '&:hover': {
                          textDecoration: 'underline',
                        },
                        userSelect: 'none',
                        my: '10px'}}>
                            {article.title}
                    </Typography>

                <Typography sx = {{
                        display: 'flex',
                        textAlign: 'left',
                        fontSize: '20px',
                        textDecoration: 'none',
                        '&:hover': {
                          textDecoration: 'underline',
                        },
                        userSelect: 'none',
                        my: '10px'}}>
                            {article.description}
                    </Typography>
                <Typography 
                    sx = {{
                    display: 'flex',
                    textAlign: 'left',
                    fontSize: '20px',
                    width: '750px',
                    color: '#454456',
                    textDecoration: 'none',
                    fontWeight: 'bold',
                    my: '17px'}}>
                        Read More...
                </Typography>
            </Box>
        </Box>

)};

export default LargeBlogCard;