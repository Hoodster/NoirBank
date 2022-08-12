import React from 'react'
import {Swiper, SwiperSlide} from 'swiper/react'
import { Navigation }from 'swiper'
import Card from '../../../../../../components/card/card'
import 'swiper/css'
import 'swiper/css/navigation'
import './cards-container.scss'

function CardsContainer() {
	return (
		<>
			<Swiper
				slidesPerView={'auto'}
				spaceBetween={10}
				navigation
				modules={[Navigation]}>
				<SwiperSlide><Card cardStyle="card1" cardNo="1001000000001001" expiration="10/22" type='Credit'/></SwiperSlide>
				<SwiperSlide><Card cardStyle="card2" cardNo="0000000000000000" expiration="10/22" type='Debit'/></SwiperSlide>
				<SwiperSlide><Card cardStyle="card3" cardNo="0000000000000000" expiration="10/22" type='Debit'/></SwiperSlide>
				<SwiperSlide><Card cardStyle="card4" cardNo="0000000000000000" expiration="10/22" type='Credit'/></SwiperSlide>
				<SwiperSlide><Card cardStyle="card1" cardNo="1001000000001001" expiration="10/22" type='Credit'/></SwiperSlide>
				<SwiperSlide><Card cardStyle="card2" cardNo="0000000000000000" expiration="10/22" type='Debit'/></SwiperSlide>
				<SwiperSlide><Card cardStyle="card3" cardNo="0000000000000000" expiration="10/22" type='Debit'/></SwiperSlide>
				<SwiperSlide><Card cardStyle="card4" cardNo="0000000000000000" expiration="10/22" type='Credit'/></SwiperSlide>
				<SwiperSlide><Card cardStyle="card1" cardNo="1001000000001001" expiration="10/22" type='Credit'/></SwiperSlide>
				<SwiperSlide><Card cardStyle="card2" cardNo="0000000000000000" expiration="10/22" type='Debit'/></SwiperSlide>
				<SwiperSlide><Card cardStyle="card3" cardNo="0000000000000000" expiration="10/22" type='Debit'/></SwiperSlide>
				<SwiperSlide><Card cardStyle="card4" cardNo="0000000000000000" expiration="10/22" type='Credit'/></SwiperSlide>
			</Swiper>
		</>
	)
}

export default CardsContainer