package registration.uz.hgpuserregistration.AdminPanel;

import lombok.AllArgsConstructor;
import org.springframework.stereotype.Service;
import org.springframework.web.servlet.support.ServletUriComponentsBuilder;
import registration.uz.hgpuserregistration.DetectorData.DetectorData;
import registration.uz.hgpuserregistration.DetectorData.DetectorRepository;
import registration.uz.hgpuserregistration.User.Entity.Gender;
import registration.uz.hgpuserregistration.User.Entity.UserProfile;
import registration.uz.hgpuserregistration.User.Model.UserProfileResponseDto;
import registration.uz.hgpuserregistration.User.Model.UserStatistics;
import registration.uz.hgpuserregistration.User.Respository.UserProfileRepository;

import java.util.ArrayList;
import java.util.List;

@Service
@AllArgsConstructor
public class AdminPanelService {

    private final UserProfileRepository profileRepository;
    private final DetectorRepository detectorRepository;
    private final UserSearchingRepository searchingRepository;
    private final AdminTableRepo adminTableRepo;

    public List<UserProfileResponseDto> getUserList() {
        List<UserProfile> userProfiles = profileRepository.findAll();
        return getUserProfileResponseDtos(userProfiles);
    }

    public UserStatistics getUserStatistics() {
        UserStatistics statistic = new UserStatistics();
        int allUsers = profileRepository.countAllUsers();
        int enabled = profileRepository.countEnabledUsers();
        int disabled = allUsers - enabled;
        statistic.setAllUsers(allUsers);
        statistic.setEnabled(enabled);
        statistic.setDisabled(disabled);
        return statistic;
    }

    public List<UserProfileResponseDto> findBySearching(
            String firstname,
            String lastname,
            String email,
            Gender gender,
            String enabled
    ){
        List<UserProfile> userProfiles = searchingRepository.findBySearchTerm(
                firstname,
                lastname,
                email,
                gender,
                enabled
        );
        return getUserProfileResponseDtos(userProfiles);
    }

    private List<UserProfileResponseDto> getUserProfileResponseDtos(List<UserProfile> userProfiles) {
        List<UserProfileResponseDto> userProfileResponseDtos = new ArrayList<>();
        for (UserProfile userProfile : userProfiles) {
            UserProfileResponseDto userProfileResponseDto = new UserProfileResponseDto();
            String imageUrl = ServletUriComponentsBuilder.fromHttpUrl("http://localhost:8087/api/user/image/")
                    .path(userProfile.getId().toString())
                    .toUriString();
            DetectorData detectorData = detectorRepository.findByUserId(userProfile);
            String detectorId = detectorData.getDetectorId();
            userProfileResponseDto.setFirstname(userProfile.getFirstname());
            userProfileResponseDto.setLastname(userProfile.getLastname());
            userProfileResponseDto.setEmail(userProfile.getEmail());
            userProfileResponseDto.setAddress(userProfile.getAddress());
            userProfileResponseDto.setPhone(userProfile.getPhone());
            userProfileResponseDto.setGender(userProfile.getGender());
            userProfileResponseDto.setEnabled(userProfile.getEnabled());
            userProfileResponseDto.setDeviceId(detectorId);
            userProfileResponseDto.setImageUrl(imageUrl);
            userProfileResponseDtos.add(userProfileResponseDto);
        }
        return userProfileResponseDtos;
    }

    public Object save(AdminRequest request) {
        AdminTable adminTable = new AdminTable();
        adminTable.setUsername(request.getUsername());
        adminTable.setPassword(request.getPassword());
        adminTable.setRole(request.getRole());
        return adminTableRepo.save(adminTable);
    }
}