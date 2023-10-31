/* eslint-disable arrow-body-style */
import React from 'react'
import './style.css';

function Carousel({images}) {
  return (
    <div className ="carousel">
        <div className='carousel-wrapper'>
            {images.map ((image, index) => {
                return <div key = {index} className='carousel_cards'>
                    <img src={image.image} alt=""/>
                    
                    </div>
            })}
        </div>
    </div>
  )
}

export default Carousel