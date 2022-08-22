/* eslint-disable no-mixed-spaces-and-tabs */
import React from 'react'
import { Fragment } from 'react'
import { wordNoNumPattern, docIDPattern, personalIDPattern, postalCodePattern } from '../../helpers/regex'
import RegistrationSlider from './components/registration-slider/registration-slider'
import Logo from '../../assets/logo/logo'
import './registration-scene.scss'
import { useDispatch } from 'react-redux'
import { setFormValue, setFormAddressValue } from '../../redux/reducers/register-reducer'
import { getForm } from './selectors'
import { Link } from 'react-router-dom'

function RegistrationScene() {
	const dispatch = useDispatch()
	const form = getForm()

	function setValue(value) {
		dispatch(setFormValue(value))
	}

	function SummaryData({property, value}) {
		return(
			<span className='meta'><span className='meta-property'>{`${property}: `}</span>{value}</span>
		)
	}

	function setAddressValue(value) {
		dispatch(setFormAddressValue(value))
	}

	return (
		<div className='nb-register-page'>
			<Logo size='md' className='nb-register-logo center'/>
			<RegistrationSlider className='nb-register-form center' slides={[
				{
					index: 0,
					title: 'Basic informations',
					formSlice: 
                        <Fragment>
                        	<input 
                        		name={RegInputs.rFirstName} 
                        		onChange={(e) => setValue({firstName: e.target.value})} 
                        		pattern={wordNoNumPattern} 
                        		placeholder='first name'></input>
                        	<input 
                        		name={RegInputs.rLastName} 
                        		onChange={(e) => setValue({lastName: e.target.value})} 
                        		pattern={wordNoNumPattern} 
                        		placeholder='last name'></input>
                        </Fragment>          
				},
				{
					index: 1,
					title: 'Identification',
					formSlice: 
                        <Fragment>
                        	<input 
                        		name={RegInputs.rID} 
                        		onChange={(e) => setValue({documentID: e.target.value})} 
                        		pattern={docIDPattern} 
                        		placeholder='id number'></input>
                        	<input 
                        		name={RegInputs.rPersonalID} 
                        		onChange={(e) => setValue({personalID: e.target.value})} 
                        		pattern={personalIDPattern} 
                        		placeholder='id card number'></input>
                        </Fragment>            
				},
				{
					index: 2,
					title: 'Home address',
					formSlice: 
                        <Fragment>
                        	<div>
                        		<input 
                        			name={RegInputs.rAddressStreet} 
                        			onChange={(e) => setAddressValue({street: e.target.value})} 
                        			placeholder='street'></input>
                        	</div>
                        	<div>
                        		<input 
                        			name={RegInputs.rAddressBuilding} 
                        			onChange={(e) => setAddressValue({building: e.target.value})}  
                        			placeholder='building'></input>
                        		<input 
                        			name={RegInputs.rAddressApartment} 
                        			onChange={(e) => setAddressValue({apartment: e.target.value})}  
                        			placeholder='apartment'></input>
                        	</div>
                        	<div>
                        		<input name={RegInputs.rAddressPostalCode} 
                        			onChange={(e) => setAddressValue({postalCode: e.target.value})}  
                        			pattern={postalCodePattern} 
                        			placeholder='postal code'></input>
                        		<input 
                        			name={RegInputs.rAddressCity} 
                        			onChange={(e) => setAddressValue({city: e.target.value})}  
                        			placeholder='city'></input>
                        	</div>
                        	<input 
                        		name={RegInputs.rAddressCountry} 
                        		onChange={(e) => setAddressValue({country: e.target.value})}  
                        		placeholder='country'></input>
                        </Fragment>                
				},
				{
					index: 3,
					title: 'Credentials',
					formSlice: 
                        <Fragment>
                        	<div>
                        		<input name={RegInputs.rEmail} onChange={(e) => setValue({email: e.target.value})}  type='email' placeholder='email'></input>
                        	</div>
                        	<div>
                        		<input name={RegInputs.rPassword} onChange={(e) => setValue({password: e.target.value})}  type='password' placeholder='password'></input>
                        	</div> 
                        </Fragment>         
				},
				{
					index: 4,
					title: 'Summary',
					formSlice: 
						<div className='summary summary-border'>
							<div className='summary'>
								<h4>Basic and contact informations</h4>
								<SummaryData property='First name' value={form.firstName}/>
								<SummaryData property='Last name' value={form.lastName}/>
								<SummaryData property='e-mail' value={form.email}/>
							</div>
							<div className='summary'>
								<h4>Identification</h4>
								<SummaryData property='Personal ID' value={form.personalID}/>
								<SummaryData property='Document ID' value={form.documentID}/>
							</div>
							<div className='summary'>
								<h4>Home address</h4>
								<span className='meta'>{`${form.address.street} ${form.address.building}${form.address.apartment ? ' / ' + form.address.apartment : ''}`}</span>
								<span className='meta'>{`${form.address.postalCode} ${form.address.city}`}</span>
								<span className='meta'>{`${form.address.country}`}</span>
							</div>
						</div>
				}
			]}/>
			<Link className='account-redirect' to='/login'>I have an account</Link>
		</div>
	)
}

export default RegistrationScene
export const RegInputs = 
{
	rFirstName: 'usrFN',
	rLastName: 'usrLN',
	rID: 'usrID',
	rPersonalID: 'usrIDNum',
	rAddressStreet: 'usrAddrStreet',
	rAddressBuilding: 'usrAddrBuilding',
	rAddressApartment: 'usrAddrApartment',
	rAddressPostalCode: 'usrAddrPostal',
	rAddressCity: 'usrAddrCity',
	rAddressCountry: 'usrAddrCountry',
	rEmail: 'usrEmail',
	rPassword: 'usrPswd'
}