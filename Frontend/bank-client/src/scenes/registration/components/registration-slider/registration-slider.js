/* eslint-disable no-unused-vars */
import React from 'react'
import { useDispatch } from 'react-redux'
import { nextSlide, previousSlide, reset } from '../../../../redux/reducers/register-reducer'
import axios from 'axios'
import { userAPI } from '../../../../helpers/endpoints'
import './registration-slider.scss'
import Stepper from '@mui/material/Stepper'
import Step from '@mui/material/Step'
import StepLabel from '@mui/material/StepLabel'
import { getCurrentSlide, getForm } from '../../selectors'
import ActionButtons from '../../../../components/action-buttons/action-buttons'

function RegistrationSlider(props) {
	const currentSlide = getCurrentSlide()
	const form = getForm()
	const dispatch = useDispatch()

	const isFirstSlide = (slide) => slide === 0
	const isLastSlide = (slide) => slide === 4

	const submitRegistration = () => {
		axios.post(`${userAPI}/register`, form)
			.then(() => {
				dispatch(reset())
			}).catch(() => {
				dispatch(reset())
			})
	}

	const createAccountActionButton = {
		text: 'Create new account',
		action: submitRegistration
	}

	const nextSlideActionButton = {
		text: 'Next',
		action: () => dispatch(nextSlide())
	}

	const previousSlideActionButton = {
		text: 'Previous',
		action: () => dispatch(previousSlide())
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
				className='reg-action-buttons'
				primaryActionButton={isLastSlide(currentSlide) ? createAccountActionButton : nextSlideActionButton}
				secondaryActionButton={!isFirstSlide(currentSlide) ? previousSlideActionButton : null} />
			<form name='reg-f' className={`${props.className ? ' ' + props.className : ''}`}>
				{
					props.slides.map(slide => {
						const isCurrentSlide = slide.index === currentSlide
						return (
							<div className='form-content' key={`f-${slide.index}`} style={!isCurrentSlide ? { display: 'none' } : null}>
								{slide.formSlice}
							</div>
						)
					})}
			</form>
		</React.Fragment>
	)
}

export default RegistrationSlider