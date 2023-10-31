/* eslint-disable arrow-body-style */
/* eslint-disable camelcase */
import React from 'react';
import { Box, Typography } from '@mui/material';
import { NavLink as RouterLink, Link, useNavigate } from 'react-router-dom';

const RecentPostBlogCard = ({ article, writter, onSelected}) => {
    const navigate = useNavigate();

    const handleClick = () => {
        onSelected(article);
        navigate(`/blog/${article.id}`);
      };
    return (
        <Box
        onClick={handleClick}
        sx={{
            display: 'flex',
            justifyContent: 'center',
            alignItems: 'center',
            flexDirection: 'row',
            width: '370px',
            height: '480px',
            mx: '2rem',
            my: '10px',
            position: 'relative',
            overflow: 'hidden',
            '&:hover': {
                textDecoration: 'underline',
                cursor: 'pointer',
              },
              userSelect: 'none',
        }}
        > 
        <Box sx = {{
            display: 'flex', justifyContent: 'center', alignItems: 'center', height: '100%', width: '35%'}}> 
            <img 
                src = {article.image}
                alt = ""              
                height= '110px'
                width= '110px'
                style={{ 
                    objectFit: 'cover',
                    overflow: 'hidden',
                    borderRadius: '55px',
                    border: '1px solid',
                    justifyContent: 'center',
                    alignItems: 'center',
                    position: 'absolute',
                    left: '10px'
                }}/>
        </Box>

        <Box sx = {{
            display: 'flex',
            justifyContent: 'center',
            flexDirection: 'column',
            height: '100%', 
            width: '65%', 
            }}> 
            <Typography sx = {{
                fontSize: "15px",
                '&:hover': {
                    textDecoration: 'underline',
                    cursor: 'pointer',
                  },
                  userSelect: 'none',
                }}> 
                {writter} 
                </Typography>
            <Typography sx = {{
                fontSize: "20px",
                '&:hover': {
                    textDecoration: 'underline',
                    cursor: 'pointer',
                  },
                  userSelect: 'none',
                }}>
                {article.title} 
            </Typography> 
        </Box>

          
        </Box>
    )
};

export default RecentPostBlogCard;