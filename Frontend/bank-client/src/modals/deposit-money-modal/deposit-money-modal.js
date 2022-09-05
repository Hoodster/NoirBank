import React from 'react'
import { useDispatch } from 'react-redux'
import ModalBase from '../../components/modal/modal-base'
import { post } from '../../helpers/api'
import { bankAccountAPI } from '../../helpers/endpoints'
import { close } from '../../redux/reducers/modal-reducer'
import { openNotification } from '../../redux/reducers/notification-reducer'
import DepositMoneyForm from './deposit-money-form'
import { getAccountNumber, getAmount } from './selectors'

function DepositMoneyModal() {
	const dispatch = useDispatch()

	const accountNumber = getAccountNumber()
	const amount = getAmount()

	const depositMoney = () => {
		const data = {
			accountNumber,
			amount
		}

		post(`${bankAccountAPI}/deposit`, data).then(() => {
			dispatch(openNotification({
				type: 'success',
				message: 'Desposit successfully added'
			}))
		}).catch(() => {
			dispatch(openNotification({
				type: 'error',
				message: 'An error has occured when depositing money.'
			}))
		})
	}

	const primaryAction = {
		action: () => depositMoney(),
		text: 'Add new deposit'
	}
    
	const secondaryAction = {
		action: () => dispatch(close()),
		text: 'Cancel'
	}

	return <ModalBase title='Deposit money to account' contentPosition='left' primaryAction={primaryAction} secondaryAction={secondaryAction}>
		<DepositMoneyForm/>
	</ModalBase>
}

export default DepositMoneyModal