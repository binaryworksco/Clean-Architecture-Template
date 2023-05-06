function (user, context, callback) {
    // Check if it's a new user signing up
    if (context.stats.loginsCount > 1) {
        return callback(null, user, context);
    }

    const axios = require('axios');

    // Replace with the URL of your API endpoint
    const apiEndpoint = 'https://ide.ads-sentry.com/api/onboarding/auth0-onboard-new-user';

    // Set the user data to be sent to your API
    const auth0User = {
        userId: user.user_id,
        username: user.username,
        email: user.email,
        name: user.name,
        firstName: user.given_name,
        lastName: user.family_name,
        picture: user.picture
    };

    // Include the shared secret and Content-Type headers
    const headers = {
        'Authorization': `Bearer ${configuration.SecretKey}`,
        'Content-Type': 'application/json'
    };

    axios.post(apiEndpoint, auth0User, { headers })
        .then(response => {
            console.log('User data sent successfully:', response.data);

            const applicationUser = response.data.applicationUsers[0];
            const applicationUserId = applicationUser.id;
            const accountId = applicationUser.accountId;

            user.app_metadata = {
                applicationUserId,
                accountId
            };
            console.log('App metadata:', user.app_metadata);

            // Persist the updated user_metadata
            auth0.users.updateAppMetadata(user.user_id, user.app_metadata)
                .then(() => {
                    callback(null, user, context);
                })
                .catch(err => {
                    console.log('Error updating user_metadata:', err);
                    callback(err);
                });
            return callback(null, user, context);
        })
        .catch(error => {
            console.error('Error sending user data:', error);
            return callback(null, user, context);
        });
}