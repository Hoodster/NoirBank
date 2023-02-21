/* eslint-disable no-unused-vars */
import { useDispatch } from 'react-redux'
import React from 'react'
import Button from '../../components/inputs/button/button'
import ModalBase from '../../components/modal/modal-base'
import GooglePayButton from '@google-pay/button-react'
import { close, open } from '../../redux/reducers/modal-reducer'
import { DEPOSIT_MONEY } from '../constants'
import { getAccountNumber, getAmount } from '../deposit-money-modal/selectors'
import { openNotification } from '../../redux/reducers/notification-reducer'
import { post } from '../../helpers/api'
import { bankAccountAPI } from '../../helpers/endpoints'
import { getAppleScript } from './applepay'

function SelectPaymentMethodModal() {
	const dispatch = useDispatch()

	const accountNumber = getAccountNumber()
	const amount = getAmount()
	const appleScript = getAppleScript()

	React.createElement('script', null, appleScript)

	const googlePayRequest = {
		apiVersion: 2,
		apiVersionMinor: 0,
		allowedPaymentMethods: [
			{
				type: 'CARD',
				parameters: {
					allowedAuthMethods: ['PAN_ONLY', 'CRYPTOGRAM_3DS'],
					allowedCardNetworks: ['MASTERCARD', 'VISA']
				},
				tokenizationSpecification: {
					type: 'PAYMENT_GATEWAY',
					parameters: {
						gateway: 'example'
					}
				}
			}
		],
		merchantInfo: {
			merchantId: '2kk4h86cxmb8bxws',
			merchantName: 'Noir Softworks Inc. (Card is not charged)'
		},
		transactionInfo: {
			totalPriceStatus: 'FINAL',
			totalPriceLabel: 'Total',
			totalPrice: amount || '0.00',
			currencyCode: 'PLN',
			countryCode: 'PL'
		}
	}

	const baseDeposit = () => {
		const data = {
			accountNumber,
			amount
		}
		post(`${bankAccountAPI}/deposit`, data).then(() => {
			dispatch(openNotification({
				type: 'success',
				message: 'Desposit successfully added'
			}))
			dispatch(close())
		}).catch(() => {
			dispatch(openNotification({
				type: 'error',
				message: 'An error has occured when depositing money.'
			}))
		})
	}

	const primaryAction = {
		action: () => dispatch(open({
			type: DEPOSIT_MONEY
		})),
		text: 'Cancel'
	}

	return <ModalBase title='Payment method' contentPosition='center' primaryAction={primaryAction}>
		<div style={{gap: '10px', display: 'flex', flexDirection: 'column'}}>
			<Button text="Base" style={{'width': '160px', 'height': '40px', 'justifyContent': 'center'}} buttonStyle='primary' type='mod' onClick={baseDeposit}/>
			<GooglePayButton
				environment='TEST'
				buttonColor='black'
				buttonType="plain"
				paymentRequest={googlePayRequest}
			/>
			<apple-pay-button buttonstyle="black" type="buy" locale="el-GR"></apple-pay-button>
		</div>
	</ModalBase>
}

export default SelectPaymentMethodModal