import React from 'react'
import { useDispatch } from 'react-redux'
import ModalBase from '../../components/modal/modal-base'
import { close, open } from '../../redux/reducers/modal-reducer'
import DepositMoneyForm from './deposit-money-form'
import { getAccountNumber, getAmount } from './selectors'

import './deposit-money-form.scss'
import { SELECT_DEPOSIT_METHOD } from '../constants'

function DepositMoneyModal() {
	const dispatch = useDispatch()
	const accountNumber = getAccountNumber()
	const amount = getAmount()

	const depositMoneyPaymentMethod = () => {
		dispatch(open({
			type: SELECT_DEPOSIT_METHOD,
			data: {
				accountNumber,
				amount
			}
		}))
	}

	const primaryAction = {
		action: () => depositMoneyPaymentMethod(),
		text: 'Select payment method'
	}
    
	const secondaryAction = {
		action: () => dispatch(close()),
		text: 'Cancel'
	}

	return <ModalBase title='Deposit money to account' contentPosition='center' primaryAction={primaryAction} secondaryAction={secondaryAction}>
		<DepositMoneyForm/>
	</ModalBase>
}

export default DepositMoneyModal