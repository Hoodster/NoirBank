/* eslint-disable indent */
/* eslint-disable no-mixed-spaces-and-tabs */
import React from 'react'
import { Fragment } from 'react'
import { wordNoNumPattern, docIDPattern, personalIDPattern, postalCodePattern } from '../../helpers/regex'
import RegistrationSlider from './components/registration-slider/registration-slider'
import Logo from '../../assets/logo/logo'
import styles from './registration-scene.module.scss'
import { useDispatch } from 'react-redux'
import { setFormValue, setFormAddressValue, reset } from '../../redux/reducers/register-reducer'
import { getForm } from './selectors'
import { Link, useNavigate } from 'react-router-dom'
import { customerAPI } from '../../helpers/endpoints'
import { openNotification } from '../../redux/reducers/notification-reducer'
import { post } from '../../helpers/api'
import clsx from 'clsx'

function RegistrationScene() {
	const dispatch = useDispatch()
	const navigate = useNavigate()
	const form = getForm()

	const setValue = (value) => {
		dispatch(setFormValue(value))
	}

	const setAddressValue = (value) => {
		dispatch(setFormAddressValue(value))
	}

	const submitRegistration = async () => {
		try {
			await post(`${customerAPI}/register`, form, true)
			dispatch(reset())
			dispatch(openNotification({
				type: 'success',
				message: 'Account added successfully.'
			}))
			navigate('/login')
		} catch (e) {
			const errorMessage = e.response.data.data.message
			let displayMessage = ''
			switch (errorMessage) {
				case 'invalid_data':
					displayMessage = 'Provided informations are invalid or incomplete.'
					break
				case 'record_already_exist':
					displayMessage = 'This email is already used.'
					break
				case 'unhandled_exception':
				default:
					displayMessage = 'Registration has failed.'
					break
			}
			dispatch(openNotification({
				type: 'error',
				message: displayMessage
			}))
		}
	}

	function SummaryData({ property, value }) {
		return (
			<span className={styles.meta}><span className='meta-property'>{`${property}: `}</span>{value}</span>
		)
	}

	return (
		<div className={styles['nb-register-page']}>
			<Logo size='md' className={clsx(styles['nb-register-logo'], styles.center)} />
			<RegistrationSlider onSubmit={submitRegistration} className={clsx(styles['nb-register-form'], styles.center)} slides={[
				{
					index: 0,
					title: 'Basic informations',
					formSlice:
						<Fragment>
							<input
								name={RegInputs.rFirstName}
								onChange={(e) => setValue({ firstName: e.target.value })}
								pattern={wordNoNumPattern}
								value={form.firstName}
								placeholder='first name' />
							<input
								name={RegInputs.rLastName}
								onChange={(e) => setValue({ lastName: e.target.value })}
								pattern={wordNoNumPattern}
								value={form.lastName}
								placeholder='last name' />
						</Fragment>
				},
				{
					index: 1,
					title: 'Identification',
					formSlice:
						<Fragment>
							<input
								name={RegInputs.rID}
								onChange={(e) => setValue({ documentID: e.target.value })}
								pattern={docIDPattern}
								placeholder='id number' />
							<input
								name={RegInputs.rPersonalID}
								onChange={(e) => setValue({ personalID: e.target.value })}
								pattern={personalIDPattern}
								placeholder='id card number' />
						</Fragment>
				},
				{
					index: 2,
					title: 'Home address',
					formSlice:
						<Fragment>
							<div className={styles.field}>
								<input
									name={RegInputs.rAddressStreet}
									onChange={(e) => setAddressValue({ street: e.target.value })}
									placeholder='street' />
							</div>
							<div className={styles.field}>
								<input
									name={RegInputs.rAddressBuilding}
									onChange={(e) => setAddressValue({ building: e.target.value })}
									placeholder='building' style={{ width: '23%' }} />
								<span style={{ fontSize: '20pt' }}>/</span>
								<input
									name={RegInputs.rAddressApartment}
									onChange={(e) => setAddressValue({ apartment: e.target.value })}
									placeholder='apartment (opt)' style={{ width: '23%' }} />
							</div>
							<div className={styles.field}>
								<input name={RegInputs.rAddressPostalCode}
									onChange={(e) => setAddressValue({ postalCode: e.target.value })}
									pattern={postalCodePattern}
									style={{ width: '23%' }}
									placeholder='postal code' />
								<input
									name={RegInputs.rAddressCity}
									onChange={(e) => setAddressValue({ city: e.target.value })}
									placeholder='city' />
							</div>
							<input
								name={RegInputs.rAddressCountry}
								onChange={(e) => setAddressValue({ country: e.target.value })}
								placeholder='country' />
						</Fragment>
				},
				{
					index: 3,
					title: 'Credentials',
					formSlice:
						<Fragment>
							<div>
								<input name={RegInputs.rEmail} onChange={(e) => setValue({ email: e.target.value })} type='email' placeholder='email' />
							</div>
							<div>
								<input name={RegInputs.rPassword} onChange={(e) => setValue({ password: e.target.value })} type='password' placeholder='password' />
							</div>
						</Fragment>
				},
				{
					index: 4,
					title: 'Summary',
					formSlice:
						<div className={clsx(styles.summary, styles['summary-border'])}>
							<div className={styles.summary}>
								<h4>Basic and contact informations</h4>
								<SummaryData property='First name' value={form.firstName} />
								<SummaryData property='Last name' value={form.lastName} />
								<SummaryData property='e-mail' value={form.email} />
							</div>
							<div className={styles.summary}>
								<h4>Identification</h4>
								<SummaryData property='Personal ID' value={form.personalID} />
								<SummaryData property='Document ID' value={form.documentID} />
							</div>
							<div className={styles.summary}>
								<h4>Home address</h4>
								<span className='meta'>{`${form.address.street} ${form.address.building}${form.address.apartment ? ' / ' + form.address.apartment : ''}`}</span>
								<span className='meta'>{`${form.address.postalCode} ${form.address.city}`}</span>
								<span className='meta'>{`${form.address.country}`}</span>
							</div>
						</div>
				}
			]} />
			<Link className={styles['account-redirect']} to='/login'>I have an account</Link>
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