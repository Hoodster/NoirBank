/* eslint-disable indent */
import React from 'react'
import AccountSettingsModal from './account-settings-modal/account-settings-modal'
import AddCardModal from './add-card-modal/add-card-modal'
import BillingHistoryModal from './billing-history-modal/billing-history-modal'
import { ACCOUNT_SETTINGS, ADD_CARD, CHOOSE_THEME, CREATE_ACCOUNT, DEPOSIT_MONEY, MAKE_TRANSFER, VIEW_BILLING_HISTORY, VIEW_SIGNIN_LOGS } from './constants'
import CreateAccountModal from './create-account-modal/create-account-modal'
import DefaultModal from './default-modal/default-modal'
import DepositMoneyModal from './deposit-money-modal/deposit-money-modal'
import MakeTransferModal from './make-transfer-modal/make-transfer-modal'
import { getModalType } from './selectors'
import SignInLogModal from './signin-log-modal/signin-log-modal'
import ThemePickerModal from './theme-picker-modal/theme-picker-modal'

function ActiveModal() {

	const getModal = () => {
		switch (getModalType()) {
			case ADD_CARD:
				return <AddCardModal />
			case CREATE_ACCOUNT:
				return <CreateAccountModal />
			case MAKE_TRANSFER:
				return <MakeTransferModal />
			case DEPOSIT_MONEY:
				return <DepositMoneyModal />
			case VIEW_SIGNIN_LOGS:
				return <SignInLogModal />
			case VIEW_BILLING_HISTORY:
				return <BillingHistoryModal />
			case CHOOSE_THEME:
				return <ThemePickerModal />
			case ACCOUNT_SETTINGS:
				return <AccountSettingsModal />
			default:
				return <DefaultModal />
		}
	}

	return getModal()
}

export default ActiveModal	