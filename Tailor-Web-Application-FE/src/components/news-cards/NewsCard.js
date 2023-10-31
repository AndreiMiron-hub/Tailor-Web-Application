/* eslint-disable arrow-body-style */
import { NavLink as RouterLink, Link, useNavigate } from 'react-router-dom';

import { Box, Typography } from '@mui/material';
import { FormattedMessage } from 'react-intl';

import AccountCircleOutlinedIcon from '@mui/icons-material/AccountCircleOutlined';

const NewsCard= ({ news, writter, onSelected }) => {
    const navigate = useNavigate();

    const handleClick = () => {
        onSelected(news);
        navigate(`/blog/${news.id}`);
      };

    return (
        <Box
        sx={{
            display: 'flex',
            justifyContent: 'center',
            alignItems: 'center',
            flexDirection: 'column',
            width: '380px',
            height: '480px',
            mx: '2rem',
            position: 'relative',
            overflow: 'hidden',
        }}
        >
            <Box
                className="image"
                sx={{
                display: 'flex',
                justifyContent: 'center',
                alignItems: 'center',
                width: '100%',
                maxHeight: '45%',
                position: 'absolute',
                top: '0',
                zIndex: 1, 
                overflow:'hidden',
                }}>
                <img src={news.image} alt="" />
            </Box>

            <Box
                className="article"
                sx={{
                display: 'flex',
                justifyContent: 'center',
                alignItems: 'center',
                flexDirection: 'column',
                width: '80%',
                height: '350px',
                backgroundColor: 'white',
                position: 'absolute',
                top: '120px',
                zIndex: 3, 
                }}
            >
                    
                <Box sx = {{
                    display: 'flex',
                    justifyContent: 'center',
                    alignItems: 'center',
                    height: '40px',
                    width: '100%',
                    backgroundColor: '#DEB18A',

                }}>
                    {news.publishDate.substring(0, 10)}
                </Box>

                <Box onClick={handleClick} 
                    sx = {{
                    display: 'flex',
                    justifyContent: 'left',
                    alignItems: 'center',
                    flexDirection: 'column',
                    height: '100%',
                    bgColor: '#DEB18A',
                    '&:hover': {
                        textDecoration: 'underline',
                        cursor: 'pointer',
                      },
                }}>
                    <Typography sx = {{
                        display: 'flex',
                        flexDirection: 'row',
                        justifyContent: 'center',
                        alignItems: 'center',
                        textAlign: 'center',
                        mt: '15px'}}>
                            <AccountCircleOutlinedIcon sx = {{
                                color: '#DEB18A', 
                                fontSize: '18px'
                                }}/>  

                            {writter}
                    </Typography>

                    <Typography sx = {{
                        textAlign: 'center', 
                        fontSize: '30px',
                        my: '10px',
                        }}> 
                        {news.title} 
                    </Typography>

                    <Typography sx = {{
                        textAlign: 'center',
                        my: '30px',
                        }}>
                        {news.description}
                    </Typography>

                    <Typography 
                        sx = {{ 
                            textDecoration: 'none',
                            color: 'black',
                            fontWeight: 'bold'
                        }}> 
                        <FormattedMessage id="lb.readMore.newsCard"/>
                    </Typography>
                </Box>
            </Box>
        </Box>
    );
};

export default NewsCard;