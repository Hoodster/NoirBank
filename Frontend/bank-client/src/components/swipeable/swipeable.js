import React from 'react'
import { Swiper, SwiperSlide } from 'swiper/react'
import { Navigation } from 'swiper'
import 'swiper/css'
import 'swiper/css/navigation'

function Swipeable(props) {
	return (
		<Swiper
			slidesPerView={'auto'}
			spaceBetween={props.space}
			navigation
			modules={[Navigation]}>
			{props.data 
				? props.data.map(node => <SwiperSlide key={Math.random()}>{node}</SwiperSlide>)
				: null
			}
		</Swiper>
	)
}

export default Swipeable