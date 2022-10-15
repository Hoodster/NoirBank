import React, { useState } from 'react'
import { useDispatch } from 'react-redux'
import ModalBase from '../../components/modal/modal-base'
import { put } from '../../helpers/api'
import { userAPI } from '../../helpers/endpoints'
import { close } from '../../redux/reducers/modal-reducer'
import { openNotification } from '../../redux/reducers/notification-reducer'
import AccountSettingsContainer from './account-settings-container'

function AccountSettingsModal() {
	const dispatch = useDispatch()
	const [isEditMode, setMode] = useState(false)

	const primaryAction = {
		text: isEditMode ? 'Save' : 'Edit',
		action: () => {
			if (!isEditMode) {
				setMode(true)
			} else {
				const emailInput = document.getElementById('account-edit-email').value
				put(`${userAPI}/email`, emailInput)
					.then(() => {
						dispatch(openNotification(
							{
								type: 'success',
								message: 'Email updated successfully. Refresh page to see changes.'
							}
						))
					})
					.catch(() => {
						dispatch(openNotification(
							{
								type: 'error',
								message: 'An error occured while updating email.'
							}
						))
					})
					.finally(() => {
						setMode(false)
					})
			}
		}
	}

	const secondaryAction = {
		text: isEditMode ? 'Cancel' : 'Close',
		action: () => {
			if (isEditMode) {
				setMode(false)
			} else {
				dispatch(close())
			}
		}
	}

	return <ModalBase title='My account' primaryAction={primaryAction} secondaryAction={secondaryAction} contentPosition='center'>
		<AccountSettingsContainer editMode={isEditMode}/>
	</ModalBase>
}

export default AccountSettingsModal