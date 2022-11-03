
// const onApplePayClick = () => {
// 	if (!ApplePaySession) {
// 		return
// 	}
		
// 	// Define ApplePayPaymentRequest
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
		
// 	// Create ApplePaySession
// 	const session = new ApplePaySession(3, request)
		
// 	session.onvalidatemerchant = async () => {
// 		// Call your own server to request a new merchant session.
// 		const merchantSession = await validateMerchant()
// 		session.completeMerchantValidation(merchantSession)
// 	}
		
// 	session.onpaymentmethodselected = () => {
// 		// Define ApplePayPaymentMethodUpdate based on the selected payment method.
// 		// No updates or errors are needed, pass an empty object.
// 		const update = {}
// 		session.completePaymentMethodSelection(update)
// 	}
		
// 	session.onshippingmethodselected = () => {
// 		// Define ApplePayShippingMethodUpdate based on the selected shipping method.
// 		// No updates or errors are needed, pass an empty object. 
// 		const update = {}
// 		session.completeShippingMethodSelection(update)
// 	}
		
// 	session.onshippingcontactselected = () => {
// 		// Define ApplePayShippingContactUpdate based on the selected shipping contact.
// 		const update = {}
// 		session.completeShippingContactSelection(update)
// 	}
		
// 	session.onpaymentauthorized = () => {
// 		// Define ApplePayPaymentAuthorizationResult
// 		const result = {
// 			status: ApplePaySession.STATUS_SUCCESS
// 		}
// 		session.completePayment(result)
// 	}
		
// 	session.oncouponcodechanged = event => {
// 		// Define ApplePayCouponCodeUpdate
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
// 		// Payment cancelled by WebKit
// 	}
		
// 	session.begin()
// }

export const getAppleScript = () => {
	const tag = document.createElement('script')
	tag.async = false
	tag.src = 'https://applepay.cdn-apple.com/jsapi/v1/apple-pay-sdk.js'
	return tag
}