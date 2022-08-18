/* eslint-disable no-unused-vars */
import React from 'react'
import { useDispatch, useSelector } from 'react-redux'
import { nextSlide, prevSlide } from '../../redux/reducers/register-reducer'
import { RegInputs } from '../../scenes/registration/registration-scene'
import axios from 'axios'
import { userAPI } from '../../helpers/endpoints'
import Button from '../inputs/button/button'
import './registration-slider.scss'
import Stepper from '@mui/material/Stepper'
import Step from '@mui/material/Step'
import StepLabel from '@mui/material/StepLabel'
import StepContent from '@mui/material/StepContent'

function RegistrationSlider(props) {
	const register = useSelector(state => state.register)
	const dispatch = useDispatch()

	function nSlide(e) {
		e.preventDefault()
		dispatch(nextSlide())
	}

	function pSlide(e) {
		e.preventDefault()
		dispatch(prevSlide())
	}

	function submitRegistration(e) {
		e.preventDefault()
		const userRegistrationData = {
			firstName: e.target[RegInputs.rFirstName].value,
			lastName: e.target[RegInputs.rLastName].value,
			email: e.target[RegInputs.rEmail].value,
			password: e.target[RegInputs.rPassword].value,
			documentID: e.target[RegInputs.rID].value,
			personalID: e.target[RegInputs.rPersonalID].value,
			address: {
				street: e.target[RegInputs.rAddressStreet].value,
				building: e.target[RegInputs.rAddressBuilding].value,
				apartment: e.target[RegInputs.rAddressApartment].value,
				postalCode: e.target[RegInputs.rAddressPostalCode].value,
				city: e.target[RegInputs.rAddressCity].value,
				country: e.target[RegInputs.rAddressCountry].value
			}
		}
		axios.post(userAPI, userRegistrationData)
			.then(() => {
			}, () => {
			})
	}

	return (
		<React.Fragment>
			<Stepper className='stepper' activeStep={register.currentSlide} alternativeLabel>
				{props.slides.map(slide => (
					<Step key={slide.title}>
						<StepLabel><h2 className='step-title'>{slide.title}</h2></StepLabel>
					</Step>
				))}
			</Stepper>
			<form name='reg-f' className={`${props.className ? ' ' + props.className : ''}`} onSubmit={(e) => submitRegistration(e)}>
				{
					props.slides.map(slide => {
						const isCurrentSlide = slide.index === register.currentSlide
						const isLastSlide = register.currentSlide === 4
						console.log(isLastSlide)
						return (
							<div className={`form-content${isLastSlide ? ' disabled' : ''}`} key={`f-${slide.index}`} style={!isCurrentSlide && !isLastSlide ? { display: 'none'} : null}>
								{isLastSlide && slide.title !== 'Summary' ? <h5>{slide.title}</h5> : null}
								{slide.formSlice}
							</div>
						)
					})}
				<div className='action-buttons'>
					{
						register.currentSlide === 0
							? null
							: <Button type='general' style='primary' text='Previous' onClick={(e) => pSlide(e)}/>
					}
					{

						register.currentSlide !== 4
							? <Button type='general' style='primary' text='Next' onClick={(e) => nSlide(e)}/>
							: <input type='submit' value='Register this shit'></input>
					}
				</div>
			</form>
		</React.Fragment>
	)
}

export default RegistrationSlider