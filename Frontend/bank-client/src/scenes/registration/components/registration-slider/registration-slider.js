/* eslint-disable no-unused-vars */
import React from 'react'
import { useDispatch } from 'react-redux'
import { nextSlide, previousSlide } from '../../../../redux/reducers/register-reducer'
import axios from 'axios'
import { userAPI } from '../../../../helpers/endpoints'
import './registration-slider.scss'
import Stepper from '@mui/material/Stepper'
import Step from '@mui/material/Step'
import StepLabel from '@mui/material/StepLabel'
import ActionButtons from '../action-buttons/action-buttons'
import { RegInputs } from '../../registration-scene'
import { getCurrentSlide, getForm } from '../../selectors'

function RegistrationSlider(props) {
	const currentSlide = getCurrentSlide()
	const form = getForm()
	const dispatch = useDispatch()

	function nSlide() {
		dispatch(nextSlide())
	}

	function pSlide() {
		dispatch(previousSlide())
	}
	
	const submitRegistration = () => {
		axios.post(userAPI, form)
			.then(() => {
			}, () => {
			})
	}

	return (
		<React.Fragment>
			<Stepper className='stepper' activeStep={currentSlide} alternativeLabel>
				{props.slides.map(slide => (
					<Step key={slide.title}>
						<StepLabel><h2 className='step-title'>{slide.title}</h2></StepLabel>
					</Step>
				))}
			</Stepper>
			<ActionButtons
				className='action-buttons'
				isFirstSlide={currentSlide === 0}
				isLastSlide={currentSlide !== 4}
				onPrevious={pSlide}
				onNext={nSlide}
				onSubmit={submitRegistration}/>
			<form name='reg-f' className={`${props.className ? ' ' + props.className : ''}`}>
				{
					props.slides.map(slide => {
						const isCurrentSlide = slide.index === currentSlide
						return (
							<div className='form-content' key={`f-${slide.index}`} style={!isCurrentSlide ? { display: 'none'} : null}>
								{slide.formSlice}
							</div>
						)
					})}
			</form>
		</React.Fragment>
	)
}

export default RegistrationSlider