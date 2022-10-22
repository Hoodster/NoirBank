import React, {useState} from 'react'
import { useDispatch } from 'react-redux'
import { setModalData } from '../../redux/reducers/modal-reducer'
import { getAccountNumber } from './selectors'
import GooglePayButton from '@google-pay/button-react'
require('https://applepay.cdn-apple.com/jsapi/v1/apple-pay-sdk.js')

function DepositMoneyForm() {
	const dispatch = useDispatch()
	const accountNumber = getAccountNumber()
	const [price, setPrice] = useState('0.00')

	let paymentRequest = {
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
			merchantName: 'NoirBank Inc. (Card is not charged)'
		},
		transactionInfo: {
			totalPriceStatus: 'FINAL',
			totalPriceLabel: 'Total',
			totalPrice: price,
			currencyCode: 'PLN',
			countryCode: 'PL'
		}
	}

	const onApplePayClick = () => {
		
	}

	// const onApplePayClick = () => {
	// 	if (!ApplePaySession) {
	// 		return
	// 	}
		
	// 	Define ApplePayPaymentRequest
	// 	const request = {
	// 		'countryCode': 'US',
	// 		'currencyCode': 'USD',
	// 		'merchantCapabilities': [
	// 			'supports3DS'
	// 		],
	// 		'supportedNetworks': [
	// 			'visa',
	// 			'masterCard',
	// 			'amex',
	// 			'discover'
	// 		],
	// 		'total': {
	// 			'label': 'NoirBank Inc. (Card is not charged)',
	// 			'type': 'final',
	// 			'amount': '1.99'
	// 		}
	// 	}
		
	// 	Create ApplePaySession
	// 	const session = new ApplePaySession(3, request)
		
	// 	session.onvalidatemerchant = async () => {
	// 		Call your own server to request a new merchant session.
	// 		const merchantSession = await validateMerchant()
	// 		session.completeMerchantValidation(merchantSession)
	// 	}
		
	// 	session.onpaymentmethodselected = () => {
	// 		Define ApplePayPaymentMethodUpdate based on the selected payment method.
	// 		No updates or errors are needed, pass an empty object.
	// 		const update = {}
	// 		session.completePaymentMethodSelection(update)
	// 	}
		
	// 	session.onshippingmethodselected = () => {
	// 		Define ApplePayShippingMethodUpdate based on the selected shipping method.
	// 		No updates or errors are needed, pass an empty object. 
	// 		const update = {}
	// 		session.completeShippingMethodSelection(update)
	// 	}
		
	// 	session.onshippingcontactselected = () => {
	// 		Define ApplePayShippingContactUpdate based on the selected shipping contact.
	// 		const update = {}
	// 		session.completeShippingContactSelection(update)
	// 	}
		
	// 	session.onpaymentauthorized = () => {
	// 		Define ApplePayPaymentAuthorizationResult
	// 		const result = {
	// 			status: ApplePaySession.STATUS_SUCCESS
	// 		}
	// 		session.completePayment(result)
	// 	}
		
	// 	session.oncouponcodechanged = event => {
	// 		Define ApplePayCouponCodeUpdate
	// 		const newTotal = calculateNewTotal(event.couponCode)
	// 		const newLineItems = calculateNewLineItems(event.couponCode)
	// 		const newShippingMethods = calculateNewShippingMethods(event.couponCode)
	// 		const errors = calculateErrors(event.couponCode)
			
	// 		session.completeCouponCodeChange({
	// 			newTotal: newTotal,
	// 			newLineItems: newLineItems,
	// 			newShippingMethods: newShippingMethods,
	// 			errors: errors,
	// 		})
	// 	}
		
	// 	session.oncancel = event => {
	// 		Payment cancelled by WebKit
	// 	}
		
	// 	session.begin()
	// }
    
	const setAmount = (amount) => {
		setPrice(amount.toString())
		dispatch(setModalData(
			{
				accountNumber,
				amount
			}
		))
	}
    
	return (
		<div>
			<span>PLN</span>
			<input type='number' onChange={(e) => setAmount(e.target.value)} placeholder="amount"/>
			<apple-pay-button buttonstyle="black" onClick={onApplePayClick} type="add-money" locale="el-GR"></apple-pay-button>
			<GooglePayButton
				environment="TEST"
				buttonColor="black"
				buttonType="plain"
				paymentRequest={paymentRequest}
			/>
		</div>
	)
}

export default DepositMoneyForm