import React from 'react'
import { useDispatch } from 'react-redux'
import ModalBase from '../../components/modal/modal-base'
import { post } from '../../helpers/api'
import { bankAccountAPI } from '../../helpers/endpoints'
import { close } from '../../redux/reducers/modal-reducer'
import { openNotification } from '../../redux/reducers/notification-reducer'
import { addBankAccount } from '../../redux/reducers/user-reducer'
import CreateAccountForm from './create-account-form'
import { getModalData } from './selectors'

function CreateAccountModal() {
	const dispatch = useDispatch()
	const modalData = getModalData()

	const createNewAccount = () => {
		post(`${bankAccountAPI}`, modalData).then((response) => {
			dispatch(addBankAccount(response.data.data))
			dispatch(openNotification({
				type: 'success',
				message: 'New bank account created'
			}))
			dispatch(close())
		})
	}

	const primaryAction = {
		text: 'Create new account',
		action: () => createNewAccount(),
		icon: 'wallet'
	}

	const secondaryAction = {
		text: 'Cancel',
		action: () => dispatch(close())
	}

	return (
		<ModalBase title='Create new account' contentPosition='center' primaryAction={primaryAction} secondaryAction={secondaryAction}>
			<CreateAccountForm />
		</ModalBase>
	)
}

export default CreateAccountModal