/* eslint-disable camelcase */
import React, { useState, useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { useNavigate } from 'react-router-dom';
import { Helmet } from 'react-helmet-async';
import { FormattedMessage } from 'react-intl';

// @mui
import {  Box , Typography, Stack } from '@mui/material';
// utils
// component
import headerImage from '../../assets/BlogBanner.jpg';
import { RecentPostBlogCard } from '../../components';

import { 
    setNewsError,
    setNewsStatus,
    setSelectedNews,
    getNews
  } from '../../config/redux/slices/NewsSlice';

export default function ArticlePage() {
    const dispatch = useDispatch();
    const navigate = useNavigate();
    const [error, setError] = useState(null);

    const {
      loading,
      news,
      newsError,
      news_status,
      selectedNews
    } = useSelector((state) => state.news)
  
  useEffect(() => {
    if(!news && !(news_status === 'failed')) 
    {
      dispatch(getNews());
    }
    if(news_status === 'failed' && newsError) {
      setError(true);
    }
    if(news && newsError && news_status === 'failed')
    {
      dispatch(setNewsError(null));
      dispatch(setNewsStatus(null));
    }
  }, [news, news_status, dispatch, newsError]);


  const onSelectedNews = (news) => {
    dispatch(setSelectedNews(news));
  };

      useEffect(() => {
        if (!selectedNews) navigate('/blog');
      }, [selectedNews]);

    return (
        <>
        <Helmet>
          <title> Blog | Tailor Website </title>
        </Helmet>
  
        <Box sx={{ 
            display: 'flex',
            overflow: 'hidden',
            position: 'relative', 
            width: '100%', 
            height: '400px',
            }}>
  
            <img
               width='100%'
               height='100%'
               style={{ objectFit: 'cover' }}
              src={headerImage}
              alt="" 
              />
          </Box>
  
          <Typography
          sx={{
            position: 'absolute',
            top: '25%',
            left: '45%',
            color: 'white',
            fontWeight: 'bold',
            textShadow: '2px 2px 4px rgba(0, 0, 0, 0.5)',
            fontSize: '50px',
            zIndex: 2,
          }}>
  
          <FormattedMessage id="lbl.blog.header"/>
  
        </Typography>
        <Box sx = {{
        display: 'flex',
        flexDirection: 'row',
        justifyContent: 'center',
        width: '100%',
        height: '100%',
        px: '30px',
      }}>
        <Box sx = {{
            display:'flex',
            justifyContent: 'center',
            flexDirection: 'column',
            alignItems: 'center',
            }}>

            <Box sx={{
                display: 'flex',
                justifyContent: 'center',
                alignItems: 'center',
                flexDirection: 'column',
                width: '90%',
                minHeight: '880px',
                height: '100%',
                position: 'relative',
                pt: '30px',
                backgroundColor: "#454456",
                my: 2,
                p: 5,
                borderRadius: '15px',
                flexGrow: '1'
                }}> 

                <img src = {selectedNews.image} 
                        alt = ""              
                        width = "900rem"
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
                    flexDirection: 'column',
                    width: '50rem',
                    minHeight: '200px',
                    height: '100%',
                    borderRadius: '0 0 20px 20px',
                    backgroundColor: "#DEB18A",
                    px: '2rem',
                    flexGrow: 1,
                    }}> 
                    <Typography sx = {{
                            display: 'flex',
                            textAlign: 'left',
                            flex: 'wrap',
                            fontSize: '30px',
                            fontWeight: 'bold',
                            textDecoration: 'none',
                            userSelect: 'none',
                            mt: '20px',
                            flexGrow: 1}}>
                                {selectedNews.title}
                        </Typography>

                    <Typography sx = {{
                            display: 'flex',
                            flex: 'wrap',
                            textAlign: 'left',
                            fontSize: '20px',
                            textDecoration: 'none',
                            userSelect: 'none',
                            flexGrow: 1}}>
                                {selectedNews.text}
                        </Typography>
                </Box> 
            </Box>
        </Box>
        <Box sx = {{
              display:'flex',
              flexDirection: 'column',
              justifyContent: 'left',
              width: '25rem',
              height:'500px',
              backgroundColor: '#FBF7F4',
              my: '30px',
              }}> 
              <Typography sx = {{ fontSize: '20px', mt: '20px', ml: '25px'}}> <FormattedMessage id="lbl.blog.recentPostsSection"/> </Typography>
              {!loading &&
                  news &&
                  news.slice(0, 4).map((article, index) => {
                      return <RecentPostBlogCard key={index + article.id} article={article} onSelected={onSelectedNews}/>
                  })}
            </Box>
        </Box>
        </>
    )
}