/* eslint-disable indent */
import React from 'react'
import AddCardModal from './add-card-modal/add-card-modal'
import BillingHistoryModal from './billing-history-modal/billing-history-modal'
import { ADD_CARD, CREATE_ACCOUNT, DEPOSIT_MONEY, MAKE_TRANSFER, VIEW_BILLING_HISTORY, VIEW_SIGNIN_LOGS } from './constants'
import CreateAccountModal from './create-account-modal/create-account-modal'
import DefaultModal from './default-modal/default-modal'
import DepositMoneyModal from './deposit-money-modal/deposit-money-modal'
import MakeTransferModal from './make-transfer-modal/make-transfer-modal'
import { getModalType } from './selectors'
import SignInLogModal from './signin-log-modal/signin-log-modal'

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
			default:
				return <DefaultModal />
		}
	}

	return (
		<React.Fragment>
			{getModal()}
		</React.Fragment>
	)
}

export default ActiveModal	