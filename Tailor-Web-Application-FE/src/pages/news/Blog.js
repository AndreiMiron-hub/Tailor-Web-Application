/* eslint-disable camelcase */
import React, { useState, useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { Helmet } from 'react-helmet-async';
import { FormattedMessage } from 'react-intl';

// @mui
import {  Box , Typography, Stack } from '@mui/material';
// utils
// component
import headerImage from '../../assets/BlogBanner.jpg';
import { RecentPostBlogCard, LargeBlogCard, ScrollToTopButton } from '../../components';
import imgText from '../../assets/Carousel_1.jpg';
import { BlogPostsSort, BlogPostsSearch } from '../../sections/@dashboard/blog';
import POSTS from '../../_mock/blog';
import imgTest from '../../assets/Carousel_2.jpg'

import { 
  setNewsError,
  setNewsStatus,
  setSelectedNews,
  getNews
} from '../../config/redux/slices/NewsSlice';

const SORT_OPTIONS = [
  { value: 'latest', label: 'Latest' },
  { value: 'popular', label: 'Popular' },
  { value: 'oldest', label: 'Oldest' },
];


export default function Blog() {

  const [openFilter, setOpenFilter] = useState(false);
  const dispatch = useDispatch();
  const [error, setError] = useState(null);

  const handleOpenFilter = () => {
    setOpenFilter(true);
  };

  const handleCloseFilter = () => {
    setOpenFilter(false);
  };

  const {
      loading,
      news,
      newsError,
      news_status,
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
          flexDirection: 'column',
          justifyContent: 'center',
          width: '70%',
          height:'100%',
          }}> 
            {!loading &&
                  news &&
                  news.slice(0, 4).map((article, index) => {
                      return <LargeBlogCard key={index + article.id} article={article} onSelected={onSelectedNews}/>
                  })}
        </Box>

        <Box sx = {{
          display:'flex',
          flexDirection: 'column',
          justifyContent: 'center',
          width: '30%',
          height:'100%',
          backgroundColor: 'white',
          py: '50px',
          }}>  

            <Stack mb={5} direction="column" alignItems="left" justifyContent="space-between" marginLeft= "15px" marginRight= "15px">
              <BlogPostsSearch posts={POSTS} />
              <BlogPostsSort options={SORT_OPTIONS} />
            </Stack>
            
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

            <Box sx = {{
              display:'flex',
              flexDirection: 'column',
              justifyContent: 'left',
              width: '25rem',
              height:'350px',
              backgroundColor: '#FBF7F4',
              my: '30px',
              }}> 
              <Typography sx = {{ fontSize: '25px', mt: '20px', ml: '25px'}}> <FormattedMessage id="lbl.blogCategory.categoriesSection"/> </Typography>

              <Typography sx = {{ fontSize: '20px', mt: '20px', ml: '25px'}}> <FormattedMessage id="lbl.blogSuits.categoriesSection"/> </Typography>

              <Typography sx = {{ fontSize: '20px', mt: '20px', ml: '25px'}}> <FormattedMessage id="lbl.categoryJackets.categoriesSection"/> </Typography>

              <Typography sx = {{ fontSize: '20px', mt: '20px', ml: '25px'}}> <FormattedMessage id="lbl.categoryTaylering.categoriesSection"/> </Typography>

              <Typography sx = {{ fontSize: '20px', mt: '20px', ml: '25px'}}> <FormattedMessage id="lbl.categoryCustomDress.categoriesSection"/> </Typography>

              <Typography sx = {{ fontSize: '20px', mt: '20px', ml: '25px'}}> <FormattedMessage id="lbl.categoryClothing.categoriesSection"/> </Typography>
            </Box>
           </Box>

      </Box>
      <ScrollToTopButton/>
      </>
      );
    }