/* eslint-disable no-mixed-spaces-and-tabs */
import React from 'react'
import { Fragment } from 'react'
import { wordNoNumPattern, docIDPattern, personalIDPattern, postalCodePattern } from '../../helpers/regex'
import RegistrationSlider from '../../components/registration-slider/registration-slider'
import Logo from '../../assets/logo/logo'
import './registration-scene.scss'

function RegistrationScene() {
	return (
		<div className='nb-register-page'>
			<Logo size='md' className='nb-register-logo center'/>
			<RegistrationSlider className='nb-register-form center' slides={[
				{
					index: 0,
					title: 'Basic informations',
					formSlice: 
                        <Fragment>
                        	<input name={RegInputs.rFirstName} pattern={wordNoNumPattern} placeholder='first name'></input>
                        	<input name={RegInputs.rLastName} pattern={wordNoNumPattern} placeholder='last name'></input>
                        </Fragment>          
				},
				{
					index: 1,
					title: 'Identification',
					formSlice: 
                        <Fragment>
                        	<input name={RegInputs.rID} pattern={docIDPattern} placeholder='id number'></input>
                        	<input name={RegInputs.rPersonalID} pattern={personalIDPattern} placeholder='id card number'></input>
                        </Fragment>            
				},
				{
					index: 2,
					title: 'Home address',
					formSlice: 
                        <Fragment>
                        	<div>
                        		<input name={RegInputs.rAddressStreet} placeholder='street'></input>
                        	</div>
                        	<div>
                        		<input name={RegInputs.rAddressBuilding} placeholder='building'></input>
                        		<input name={RegInputs.rAddressApartment} placeholder='apartment'></input>
                        	</div>
                        	<div>
                        		<input name={RegInputs.rAddressPostalCode} pattern={postalCodePattern} placeholder='postal code'></input>
                        		<input name={RegInputs.rAddressCity} placeholder='city'></input>
                        	</div>
                        	<input name={RegInputs.rAddressCountry} placeholder='country'></input>
                        </Fragment>                
				},
				{
					index: 3,
					title: 'Credentials',
					formSlice: 
                        <Fragment>
                        	<div>
                        		<input name={RegInputs.rEmail} type='email' placeholder='email'></input>
                        	</div>
                        	<div>
                        		<input name={RegInputs.rPassword} type='password' placeholder='password'></input>
                        	</div>
                        </Fragment>         
				},
				{
					index: 4,
					title: 'Summary',
					formSlice: null
				}
			]}>
			</RegistrationSlider>
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