import React from 'react'
import AdminAccounts from '../../admin/admin-accounts'
import AdminBankAccounts from '../../admin/admin-bankaccounts'

function AdminContainer() {
	return(
		<React.Fragment>
			<AdminAccounts />
			<AdminBankAccounts />
		</React.Fragment>
	)
}

export default AdminContainer